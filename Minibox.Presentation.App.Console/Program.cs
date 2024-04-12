using System.Data;
using System.Data.OleDb;
using Minibox.Presentation.Core.Data.Context.Main.Schema.Dbo.Table.AdministrativeDirectory;

var countries = new List<Country>();
var provinces = new List<Province>();
var districts = new List<District>();
var wards = new List<Ward>();

var vietNam = new Country()
{
    Name = "Việt Nam",
    Code = "VN",
    PrefixPhoneCode = "+84"
};
countries.Add(vietNam);

var filePath = @"C:\Users\Tran Tin DU1.18\Downloads\donvihanhchinhVietNam.xls";



Console.ReadKey();
