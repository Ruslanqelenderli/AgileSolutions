using System.ComponentModel.DataAnnotations;

namespace AgileSolutions.UI.ViewModels.DepartmentViewModels
{
    public class DepartmentUpdateViewModel
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Minimum 3 characters")]
        [MaxLength(20, ErrorMessage = "Maximum 20 characters")]
        public string Name { get; set; }
        public bool State { get; set; }
        public int? ParentDepartmentId { get; set; }
    }
}
