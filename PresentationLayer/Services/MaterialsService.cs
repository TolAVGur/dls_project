﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinesLayer;
using BusinesLayer.Repositories;
using PresentationLayer.ViewModels;
using DataLayer.Entities;

namespace PresentationLayer.Services
{
    public class MaterialsService 
    {
        private DataManager _dataManager;
        public MaterialsService (DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public MaterialViewModel TransitMaterialToView(int materialId)
        {
            var vm = new MaterialViewModel()
            {
                // public Material
                Material = _dataManager.MatRepos.GetMaterialById(materialId)
            };

            var dir_id = vm.Material.DirectoryId;
            var dir = _dataManager.DirRepos.GetDirectoryById(dir_id, true);

                // public DirectoryId
            vm.DirectoryId = dir_id;

            var current = dir.Materials.FirstOrDefault(x => x.Id == vm.Material.Id);
            var current_index = dir.Materials.IndexOf(current);
            var N = dir.Materials.Count();

            // PrevMaterial, NextMaterial
            if (current_index != 0)
                vm.PrevMaterial = dir.Materials[current_index - 1];
            if (current_index != N - 1)
                vm.NextMaterial = dir.Materials[current_index + 1];

            return vm;
        }

        public MaterialViewModel SaveMaterialToDb(MaterialViewModel vm)
        {
            Material material = null;

            if(vm.Id != 0){
                material = _dataManager.MatRepos.GetMaterialById(vm.Id);
            } else {
                material = new Material();
            }

            material.Title = vm.Title;
            material.Html = vm.Html;
            material.DirectoryId = vm.DirectoryId;

            _dataManager.MatRepos.SaveMaterial(material);

            return TransitMaterialToView(material.Id);

        }
    }
}
