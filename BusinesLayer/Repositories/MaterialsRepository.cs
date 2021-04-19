﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinesLayer.Interfaces;
using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusinesLayer.Repositories
{
    public class MaterialsRepository : IMaterialsRepository
    {
        private EFDBContext _context;
        public MaterialsRepository(EFDBContext context)
        {
            _context = context;
        }
       
        public void DeleteMaterial(Material m)
        {
            _context.Materials.Remove(m);
            _context.SaveChanges();
        }

        public IEnumerable<Material> GetAllMaterials()
        {
            return _context.Materials.ToList();
        }

        public Material GetMaterialById(int materialId)
        {
            return _context.Materials.FirstOrDefault(x=> x.Id == materialId);

        }

        public IEnumerable<Material> GetMaterialsByDirectory(int directoryId)
        {
            return _context.Materials.Where(x => x.DirectoryId == directoryId).ToList();
        }

        public void SaveMaterial(Material m)
        {
            if (m.Id == 0)
                _context.Materials.Add(m);
            else
                _context.Entry(m).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}