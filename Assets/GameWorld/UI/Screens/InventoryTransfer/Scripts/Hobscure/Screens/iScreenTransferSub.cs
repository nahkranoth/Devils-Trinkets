namespace Hobscure.Screens
{
    public interface iScreenTransferSub
    {
        iScreenTransferSubModel GetModel();

        void ApplyModel(iComponentModel data);
    }
}