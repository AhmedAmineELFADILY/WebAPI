using WebAPI.Models.Dto;

namespace WebAPI.Data
{
    public class EtudiantStore
    {
        public static List<EtudiantDto> EtudiantList =  new List<EtudiantDto>
            {
                new EtudiantDto{Id=1,Name = "Ahmed",Lastname="Amine" },
                new EtudiantDto{Id=2,Name = "Ahmed2",Lastname="Amine2" },
            };
    }
}
