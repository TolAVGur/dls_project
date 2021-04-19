﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinesLayer.Interfaces;
using DataLayer.Entities;
using DataLayer;
using Microsoft.EntityFrameworkCore;

namespace BusinesLayer.Repositories
{
    public class DirectoriesRepository : IDirectoriesRepository
    {
        private EFDBContext _context;
        public DirectoriesRepository(EFDBContext context)
        {
            _context = context;
        }

        public void DeleteDirectory(Directory dir)
        {
            _context.Directories.Remove(dir);
            _context.SaveChanges();
        }

        public IEnumerable<Directory> GetAllDirectories(bool includeMaterials = false)
        {
            if (includeMaterials)
                return _context.Directories.Include(x => x.Materials).AsNoTracking().ToList();
            else
                return _context.Directories.ToList();
        }

        public Directory GetDirectoryById(int directoryId, bool includeMaterials = false)
        {
            if (includeMaterials)
                return _context.Directories.Include(x => x.Materials).AsNoTracking()
                    .FirstOrDefault(x=> x.Id == directoryId);
            else
                return _context.Directories.FirstOrDefault(x => x.Id == directoryId);
        }

        public void SaveDirectory(Directory dir)
        {
            if (dir.Id == 0)
                _context.Directories.Add(dir);
            else
                _context.Entry(dir).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
