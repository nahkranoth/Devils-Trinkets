using Hobscure.Items;
using Hobscure.UI;
using System.Collections.Generic;
namespace Hobscure.Screens
{
    public interface iScreenTransferSubModel
    {
        void AddContainers(List<Item> items);
        List<Item> GetSelectedAsItems();
        List<Item> GetAllItems();
        void RemoveSelected();
        List<ItemContainerModel> GetSelectedContainers();
        void MergeWithInventory(List<ItemContainerModel> itemContainers);
        void DeselectAll();
        bool IsActive();

    }
}