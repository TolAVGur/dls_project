using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities;

namespace BusinesLayer.Interfaces
{
    public interface IMaterialsRepository
    {
        IEnumerable<Material> GetAllMaterials();
        IEnumerable<Material> GetMaterialsByDirectory(int directoryId);
        Material GetMaterialById(int materialId);
        void SaveMaterial(Material m);
        void DeleteMaterial(Material m);
    }
}
