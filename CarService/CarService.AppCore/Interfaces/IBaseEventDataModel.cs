using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.AppCore.Interfaces
{
    public interface IBaseEventDataModel
    {
        Guid Id { get; set; }
    }
}
