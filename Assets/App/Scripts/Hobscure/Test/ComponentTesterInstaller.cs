using Hobscure.UI;
using UnityEngine;
using Zenject;

public class ComponentTesterInstaller : MonoInstaller<ComponentTesterInstaller>
{

    //components
    public GameObject prefabButton;
    public GameObject prefabIconButton;
    public GameObject prefabIconStateButton;
    public GameObject prefabScrollList;
    public GameObject prefabTextField;
    public GameObject itemContainer;


    public override void InstallBindings()
    {

        Container.Bind<ScrollList>().FromPrefab(prefabScrollList);
        Container.Bind<CustomTextField>().FromPrefab(prefabTextField);
        Container.Bind<ItemContainer>().FromPrefab(itemContainer);

    }
}