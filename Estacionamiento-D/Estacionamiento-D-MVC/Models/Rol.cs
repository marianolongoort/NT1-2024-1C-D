using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Estacionamiento_D_MVC.Models
{
    public class Rol : IdentityRole<int>
    {
        public Rol() : base() { }

        public Rol(string rolName) : base(rolName) { }

  
        public override string Name
        {
            get { return base.Name; }
            set { base.Name = value; }
        }

        public override string NormalizedName
        {
            get => base.NormalizedName;
            set => base.NormalizedName = value;
        }

    }
}
