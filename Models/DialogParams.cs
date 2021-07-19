using System.ComponentModel.DataAnnotations;

namespace ChatboxApi.Controllers
{
    public class DialogParams
    {
        [Required]
        public int type { get; set; }
        public string occupants_ids { get; set; }
        public string admins_ids { get; set; }
        public string name { get; set; }
        public string photo { get; set; }
    }
}