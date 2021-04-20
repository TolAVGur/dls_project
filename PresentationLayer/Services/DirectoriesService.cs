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
    public class DirectoriesService
    {
        private DataManager _dataManager;
        private MaterialsService _materialsService;

        public DirectoriesService(DataManager dataManager)
        {
            _dataManager = dataManager;
            _materialsService = new MaterialsService(dataManager);
        }

        public DirectoryViewModel TransitDirectoryToView(int directory_id)
        {
            var dir = _dataManager.DirRepos.GetDirectoryById(directory_id, true);
            List<MaterialViewModel> matts_list = new List<MaterialViewModel>();
            foreach (var item in dir.Materials)
                matts_list.Add(_materialsService.TransitMaterialToView(item.Id));
            DirectoryViewModel vm = new DirectoryViewModel()
            {
                Directory = dir, Materials = matts_list
            };
            return vm;
        }

        public List<DirectoryViewModel> TransitDirectoriesToView()
        {
            var dirs = _dataManager.DirRepos.GetAllDirectories();
            List<DirectoryViewModel> dirs_list = new List<DirectoryViewModel>();
            foreach (var item in dirs)
                dirs_list.Add(TransitDirectoryToView(item.Id));

            //return _dataManager.DirRepos.GetAllDirectories().Select(d => new DirectoryViewModel { Directory = d }).ToList();
            return dirs_list;
        }

        public DirectoryViewModel GetDirectoryEditModel(int directoryId = 0)
        {
            if(directoryId != 0)
            {
                var dbModel = _dataManager.DirRepos.GetDirectoryById(directoryId);
                var editModel = new DirectoryViewModel()
                {
                    Id = dbModel.Id,
                    Title = dbModel.Title,
                    Html = dbModel.Html
                };
                return editModel;
            }
            else
            {
                return new DirectoryViewModel() { };
            }
        }

        public DirectoryViewModel SaveDirectoryEditModel(DirectoryViewModel directoryEditModel)
        {
            Directory directoryDbModel;
            if(directoryEditModel.Id != 0)
                directoryDbModel = _dataManager.DirRepos.GetDirectoryById(directoryEditModel.Id);
            else
                directoryDbModel = new Directory();

            directoryDbModel.Title = directoryEditModel.Title;
            directoryDbModel.Html = directoryEditModel.Html;

            _dataManager.DirRepos.SaveDirectory(directoryDbModel);
            return TransitDirectoryToView(directoryDbModel.Id);
        }

        public DirectoryViewModel CreateNewDirectoryModel()
        {
            return new DirectoryViewModel() { };
        }

        public void DeleteDirectoryFromDb(int directoryId)
        {
            var delDirectory = _dataManager.DirRepos.GetDirectoryById(directoryId);
            _dataManager.DirRepos.DeleteDirectory(delDirectory);
        }
    }
}
