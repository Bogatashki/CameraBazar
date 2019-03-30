using CameraBazar.Models.Attribute;
using CameraBazar.Models.Enumeration;
using CameraBazzar.Models;
using CameraBazzar.Models.EntityModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Resources;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CameraBazar.Models.Models
{
    public class Camera
    { 
        public int Id { get; set; }
        
        [Range(1, int.MaxValue, ErrorMessage = "Select a manufacturer.")]
        public Make Make { get; set; }
        [RegularExpression("\\S*\\d*?-[A-Z]*[0-9]*", ErrorMessage = "The Model can be contain only uppercase letters, digits and dash (“-“). ")]
        public string Model { get; set; }
        //[RegularExpression(@"^\d+.\d{0,2}$", ErrorMessage = "Price can't have more than 2 decimal places")]
        public decimal Price { get; set; }
        //[StringLength(3, ErrorMessage = "The Quantity can be number in range 0 – 100.")]
        [Range(0, 100, ErrorMessage = "The Quantity can be number in range 0 – 100.")]
        public int Quantity { get; set; }
        [Range(0, 30, ErrorMessage = "Please use values between 0 to 30")]
        public int MinShutterSpeed { get; set; }
        [Range(2000, 8000, ErrorMessage = "Please use values between 2000 to 8000")]
        public int MaxShutterSpeed { get; set; }
        [Range(50, 100, ErrorMessage = "Please use values between 50 to 100")]
        public int MinIso { get; set; }
        [MaxIso]
        public int MaxIso { get; set; }

        public bool IsFullFrame { get; set; }
        [StringLength(15, ErrorMessage = "The Video Resolution can be text no longer than 15 symbols.")]
        public string VideoResolution { get; set; }

        public bool Spot { get; set; }

        public bool CenterWeighted { get; set; }

        public bool Evaluative { get; set; }
        [StringLength(6000, ErrorMessage = "The Video Resolution can be text no longer than 6000 symbols.")]
        public string Description { get; set; }
        [RegularExpression("^(http|https)://(.*)", ErrorMessage = "The ImageUrl must be start with http:// or https://")]
        public string ImageUrl { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public string IsFullFrameYesNo
        {
            get
            {
                return IsFullFrame ? "Yes" : "NO";
            }
        }
    }
}
