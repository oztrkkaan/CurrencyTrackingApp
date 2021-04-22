var EvdsServices = {
    GetListByCodeAndDate: function (requestModel) {
        console.log(JSON.stringify(requestModel));
        return
        $.ajax({
            contentType: 'application/json',
            url: 'https://localhost:44314/api/GetListByCodeAndDate',
            type: 'POST',
            dataType: 'JSON',
            data: JSON.stringify(request),
            success: function (result) {
                console.log(result);
            }
        });

    }
}