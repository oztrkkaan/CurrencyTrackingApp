$(document).ready(function () {


    var hiddenStartDate = $("#StartDate");
    var hiddenEndDate = $("#EndDate");

    hiddenStartDate.val(moment().format("DD.MM.yyyy"));
    hiddenEndDate.val(moment().format("DD.MM.yyyy"));


    $("#startDatePicker").daterangepicker({
        singleDatePicker: true,
        showDropdowns: true,
        minYear: 1901,
        maxYear: parseInt(moment().format("YYYY"), 10),
        locale: {
            format: "DD.MM.YYYY"
        }
    }, function (startDate) {
        startDate = moment(startDate).format("DD.MM.yyyy");
        hiddenStartDate.val(startDate);
    });

    $("#endDatePicker").daterangepicker({
        singleDatePicker: true,
        showDropdowns: true,
        minYear: 1901,
        maxYear: parseInt(moment().format("YYYY"), 10),
        locale: {
            format: "DD.MM.YYYY"
        }
    }, function (endDate) {
        endDate = moment(endDate).format("DD.MM.yyyy");
        hiddenEndDate.val(endDate);
    });





    $("#btnGetCurrencyData").on("click", function () {

        var currencyOperationType = $("#CurrencyDto_OperationType").val();
        var startDate = $("#StartDate").val();
        var endDate = $("#EndDate").val();
        var currencyCode = $("#CurrencyDto_Code").val();
        var responseType = "json";

        console.log(moment(startDate, "DD.MM.YYYY").format("YYYY-MM-DD"));
        console.log(startDate);

        var request = {
            "CurrencyCode": currencyCode,
            "OperationType": currencyOperationType,
            "StartDate": moment(startDate, "DD.MM.YYYY").format("YYYY-MM-DD"),
            "EndDate": moment(endDate, "DD.MM.YYYY").format("YYYY-MM-DD"),
            "ResponseType": responseType
        };
        var ratingDataList = [];

        $.ajax({
            contentType: 'application/json',
            url: 'https://localhost:44314/api/GetListByCodeAndDate',
            type: 'POST',
            dataType: 'JSON',
            data: JSON.stringify(request),
            success: function (result) {
                $.each(result, function (i, val) {
                    ratingDataList.push(val.rating);
                 
                })

                

            }, 
        }).done(function (data) {
            console.log(ratingDataList);
            var dataList

           
            chart.updateSeries([{
                name: data.currencyCode,
                data: ratingDataList
            }])

        });


    });
    initChart();


})
var chart;

var initChart = function (data) {
    var element = document.getElementById("currency-chart");

    var height = parseInt(KTUtil.css(element, 'height'));

    var labelColor = KTUtil.getCssVariableValue('--bs-gray-500');
    var borderColor = KTUtil.getCssVariableValue('--bs-gray-200');
    var strokeColor = KTUtil.getCssVariableValue('--bs-gray-300');

    var color1 = KTUtil.getCssVariableValue('--bs-primary');
    var color1Light = KTUtil.getCssVariableValue('--bs-light-warning');



    if (!element) {
        return;
    }

    var options = {
        series: [{
            name: '',
            data: []
        }],
        chart: {
            fontFamily: 'inherit',
            type: 'area',
            height: height,
            toolbar: {
                show: false
            },
            zoom: {
                enabled: false
            },
            sparkline: {
                enabled: true
            }
        },
        plotOptions: {},
        legend: {
            show: false
        },
        dataLabels: {
            enabled: false
        },
        fill: {
            type: 'solid',
            opacity: 1
        },
        stroke: {
            curve: 'smooth',
            show: true,
            width: 2,
            colors: [color1]
        },
        xaxis: {
            x: 0,
            offsetX: 0,
            offsetY: 0,
            padding: {
                left: 0,
                right: 0,
                top: 0,
            },
           // categories: ['Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul'],
            axisBorder: {
                show: false,
            },
            axisTicks: {
                show: false
            },
            labels: {
                show: false,
                style: {
                    colors: labelColor,
                    fontSize: '12px'
                }
            },
            crosshairs: {
                show: false,
                position: 'front',
                stroke: {
                    color: strokeColor,
                    width: 1,
                    dashArray: 3
                }
            },
            tooltip: {
                enabled: true,
                formatter: undefined,
                offsetY: 0,
                style: {
                    fontSize: '12px'
                }
            }
        },
        yaxis: {
            y: 0,
            offsetX: 0,
            offsetY: 0,
            padding: {
                left: 0,
                right: 0
            },
            labels: {
                show: false,
                style: {
                    colors: labelColor,
                    fontSize: '12px'
                }
            }
        },
        states: {
            normal: {
                filter: {
                    type: 'none',
                    value: 0
                }
            },
            hover: {
                filter: {
                    type: 'none',
                    value: 0
                }
            },
            active: {
                allowMultipleDataPointsSelection: false,
                filter: {
                    type: 'none',
                    value: 0
                }
            }
        },
        tooltip: {
            style: {
                fontSize: '12px'
            },
            y: {
                formatter: function (val) {
                    return  val 
                }
            }
        },
        colors: [color1Light],
        grid: {
            borderColor: borderColor,
            strokeDashArray: 4,
            padding: {
                top: 0,
                bottom: 0,
                left: 0,
                right: 0
            }
        },
        markers: {
            colors: [color1],
            strokeColor: [color1],
            strokeWidth: 3
        }
    };

    chart = new ApexCharts(element, options);
    chart.render();
}