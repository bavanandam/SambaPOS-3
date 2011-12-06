﻿using System.Linq;
using Samba.Domain.Models.Tables;
using Samba.Domain.Models.Tickets;
using Samba.Localization.Properties;
using Samba.Persistance.Data;
using Samba.Presentation.Common.ModelBase;

namespace Samba.Modules.RestaurantModule
{
    public class TableScreenListViewModel : EntityCollectionViewModelBase<TableScreenViewModel, TableScreen>
    {
        protected override TableScreenViewModel CreateNewViewModel(TableScreen model)
        {
            return new TableScreenViewModel(model);
        }

        protected override TableScreen CreateNewModel()
        {
            return new TableScreen();
        }

        protected override string CanDeleteItem(TableScreen model)
        {
            if (Dao.Query<Department>(x => x.PosTableScreens.Any(y => y.Id == model.Id)) != null)
                return Resources.DeleteErrorTableViewUsedInDepartment;
            return base.CanDeleteItem(model);
        }
    }
}