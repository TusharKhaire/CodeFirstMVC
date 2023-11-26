
$(document).ready(function () {
   // GetCustomer();
    
});
    $("#btnShow").on("click", function () {
        GetCustomer();
    });
function GetCustomer() {
    $.ajax({
        url: '/CustomerDetails/ReturnData',
        type: 'Get',
        dataType: 'Json',
        success: OnSuccess
    });
}
function OnSuccess(response) {
    $('#dataTableData').DataTable({
        bprocessing: true,
        bLengthChange: true,
        lengthMenu: [[5, 10, 25, -1], [5, 10, 25, "All"]],
        bfilter: true,
        bSort: true,
        bPaginate: true,
        data: response,
        columns: [
            {
                data: 'Id',
                render: function (data, type, row, meta) {
                    return row.Id;
                },
                visible: false
                
            },
            {
                data: 'CustomerName',
                render: function (data, type, row, meta) {
                    return row.CustomerName;
                }
            },
            {
                data: 'Address',
                render: function (data, type, row, meta) {
                    return row.Address;
                }
            },
            {
                data: 'State',
                render: function (data, type, row, meta) {
                    return row.State;
                }
            },
            {
                data: 'Dist',
                render: function (data, type, row, meta) {
                    return row.Dist;
                }
            },
            {
                data: 'MobileNo',
                render: function (data, type, row, meta) {
                    return row.MobileNo;
                }
            },
            {
                data: 'Email',
                render: function (data, type, row, meta) {
                    return row.Email;
                }
            },
            {
                data: 'DateOfBirth',
                render: function (data, type, row, meta) {
                    return row.DateOfBirth;
                }
            },
            {
                data: 'OpeningBal',
                render: function (data, type, row, meta) {
                    return row.OpeningBal;
                }
            },
            {
                data: 'ClosingBal',
                render: function (data, type, row, meta) {
                    return row.ClosingBal;
                }
            }
        ]
    }); 
}


//AccountDisplayModule = function () {

//    var uri = {
//        GetAccountDisplay: '/AccountDisplay/GetAccountDisplay',
//        GetAccounts: '/AccountDisplay/GetAccounts',

//    }

//    var modeEnum = { "Find": 1, "Show": 2 };
//    Object.freeze(modeEnum);

//    var controls = {
//        buttons: {
//            show: $("#btnShow")
//            //abort: $("#btnAbort"),
//            //print: $("#btnPrint"),
//            //save: $("#btnSave")
//        },
//        divs: {
//            //accountDisplay: $("#divAccountDisplay"),
//            //buttons: $("#divButtons")
//        },
//        tables: {
//            DispalyCustomers: $("#dataTableData")
//        },
//        dropdown: {
//           // customer: $("#ddlCustomer")
//        },
//        textbox: {


//        }
//    }

//    var uiControls = {
//        tables: {
//        },
//        dropdown: {
//        }
//    }

//    var config = {
//        mode: modeEnum.Find,
//        allCombos: []
//    }

//    var pageVar = {

//    };

//    var formData = {
//        details: {

//        }
//    }

//    var initInvoices = function () {
//        debugger;
//        dt = null;
//        pageVar.isInvoicesInit = true;
//        pageVar.clientArea = $(window).height() - 30;
//        var tableHeight = ((pageVar.clientArea - 205) > 300 ? (pageVar.clientArea - 205) : 300);
//        dt = $("#dataTableData").DataTable({
//            ajax: {
//                url: '/CustomerDetails/GetInvoices',
//                type:"Get"
//            },
//            "serverSide": true,
//            "processing": true,
//            columns: [
//                { name: "CustomerName", data: "CustomerName", title: "Customer Name", visible: true },
//                { name: "Address", data: "Address", title: "Address", visible: true },
//                { name: "State", data: "State", title: "State", visible: true },
//                { name: "Dist", data: "Dist", title: "Dist", visible: true },
//                { name: "MobileNo", data: "MobileNo", title: "MobileNo", visible: true },
//                { name: "Email", data: "Email", title: "Email", visible: true },
//                { name: "DateOfBirth", data: "DateOfBirth", title: "Date Of Birth", visible: true },
//                { name: "OpeningBal", data: "OpeningBal", title: "OpeningBal", visible: true },
//                { name: "ClosingBal", data: "ClosingBal", title: "ClosingBal", visible: true },
//                {
//                    "width": "7%",
//                    "defaultContent":
//                        '<button class="btn-edit" type="button">Edit</button>'
//                },
//                {
//                    "width": "7%",
//                    "defaultContent":
//                        '<button class="btn-delete"  type="button">Delete</button>'
//                }
//            ],
//            //"lengthMenu": [[10, 25, 50, 100], [10, 25, 50, 100]],
//            info: false,
//            destroy: false,
//            select: {
//                style: 'single'
//            },
//            order: [[0, "desc"]]
//        });

//    };


//    $("#btnShow").on("click", function () {
//        debugger;
//        alert("show");
//        initInvoices();
//    });


//    var init = function () {
//        //initCombos();

//    };

//    return { init: init };
//}();
//AccountDisplayModule.init();