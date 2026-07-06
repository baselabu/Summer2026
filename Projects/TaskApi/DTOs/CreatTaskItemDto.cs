using System.ComponentModel.DataAnnotations;


namespace TaskApi.DTOs
{
    public class CreatTaskItemDto
    {
        [Required]
        public string Title { get; set; } = "";

        [Required]
        public string Name { get; set; } = "";
    }
}