
$(document).ready(function () {
   // GetCustomer();
    
});
    $("#btnShow").on("click", function () {
        GetCustomer();
    });
function GetCustomer() {
    var name = $("#txtName").val();
    $.ajax({
        url: '/CustomerDetails/ReturnData',
        type: 'Get',
        data: { Name:name },
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
            },
            {
                data: 'Action',
                render: function (data, type, row, meta) {
                    return '<input type="checkbox" id="chk_' + row.Id + '" class="btn btn-primary" onclick="myFunction(' + row.ClosingBal + ', \'' + row.Id + '\')">';
                }
            },
            {
                data: 'Action',
                render: function (data, type, row, meta) {
                    var container = '<div style="display: flex;">';

                    var firstButton = '<button type="button" id="' + row.Id + '" class="btn btn-primary" onclick="myFunction(' + row.ClosingBal + ')">Closing</button>';
                    var secondButton = '<button type="button" id="secondBtn_' + row.Id + '" class="btn btn-secondary" onclick="anotherFunction(' + row.OpeningBal + ')">Opening</button>';

                    var containerEnd = '</div>';

                    return container + firstButton + secondButton + containerEnd;
                    //return '<button type="button" id=' + row.Id + ' class="btn btn-primary" onclick="myFunction(' + row.ClosingBal + ')">Click me</button>';
                }
            }
        ],
        columnDefs: [
            { width: '2px', targets: [6] }
        ]
    }); 
}

function myFunction(rowID) {
    console.log('Button clicked for row with closing balance is :', rowID);
    alert(rowID);
}
function anotherFunction(rowID) {
    console.log('Button clicked for row with opening balance is :', rowID);
    alert(rowID);
}
//                { name: "State", data: "State", title: "State", visible: true },
