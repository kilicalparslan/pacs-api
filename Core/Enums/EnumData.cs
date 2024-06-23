using System.ComponentModel.DataAnnotations;

namespace pdksApi.Core.Enums
{
    public class EnumData
    {
        public enum UploadType
        {
            Resim = 1,
            Video = 2
        }

        public enum Statu
        {
            Taslak = 0,
            Onayda = 1,           
            Revize = 2,
            Tamamlandi = 3,
            İptal = 9
        }
        public enum Esort
        {
            [Display(Name = "OrderBy")]
            ASC = 1,
            [Display(Name = "OrderByDescending")]
            DESC = 2,
        }

        public enum LogType
        {
            GroupRecordDelete = 1,
            Login = 2
        }
    }
}
