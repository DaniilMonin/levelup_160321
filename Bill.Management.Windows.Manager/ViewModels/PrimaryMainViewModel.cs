﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Bill.Management.Rest.Service.Client.Connection;
using Bill.Management.Windows.Manager.ViewModels.Data;
using Bill.Management.Windows.ViewModels;
using Bill.Management.Windows.ViewModels.Commands;
using Bill.Management.Windows.ViewModels.Factories;
using Bill.Management.Windows.ViewModels.Services.Dialog;
using Bill.Management.Windows.ViewModels.View;
using BillManagement.Core.Abstractions.Data.Results;
using BillManagement.Imlementations.Data;
using Nito.AsyncEx.Synchronous;

namespace Bill.Management.Windows.Manager.ViewModels
{
    public sealed class PrimaryMainViewModel : MainViewModel
    {
        private readonly IDialogService _dialogService;
        private readonly ICustomDynamicFactory<BaseViewModel> _viewModeFactory;
        private ICommand _fillGridCommand;
        private readonly ObservableCollection<IUserViewModel> _users = new ObservableCollection<IUserViewModel>();

        public PrimaryMainViewModel(IDialogService dialogService, ICustomDynamicFactory<BaseViewModel> viewModeFactory)
        {
            _dialogService = dialogService;
            _viewModeFactory = viewModeFactory;
            FillGridCommand = new RelayCommand(x => FillUserGridByService());
        }

        public ICommand FillGridCommand
        {
            get => _fillGridCommand;
            set => _fillGridCommand = value;
        }

        public ObservableCollection<IUserViewModel> Users
        {
            get => _users;
        }

        private void FillUserGridByService()
        {
            /*_users.Add(new UserViewModel(new User
            {
                FirstName = Guid.NewGuid().ToString()
            }));*/

            ChildViewModel baseViewModel = _viewModeFactory.Create<ChildViewModel>();
            baseViewModel.Title = "This is child window!";
            baseViewModel.SomeText = "HALLO!";

            _dialogService.ShowDialog<IChildDialogView, ChildViewModel>(baseViewModel);

            Title = baseViewModel.SomeText;


            /*IBillManagementClient client = ClientFactory.Create("http://localhost:58755");

            IOperationResult<IReadOnlyList<User>> result = client.GetClients().WaitAndUnwrapException();

            if (result.Succeed)
            {
                Users = result.Result;
            }*/
        }
    }
}