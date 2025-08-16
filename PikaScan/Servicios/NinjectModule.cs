using Ninject;
using Ninject.Modules;

namespace PikaScan.Servicios    
{
    public class CompositionRoot
    {
        private static IKernel _ninjectKernel;

        public static void Wire(INinjectModule module)
        {
            _ninjectKernel = new StandardKernel(module);
        }

        public static T Resolve<T>()
        {
            return _ninjectKernel.Get<T>();
        }
    }


    public class ApplicationModule : NinjectModule
    {
        public override void Load()
        {
            //Bind(typeof(IAppSettings)).To(typeof(AppSettings)).InSingletonScope();
            //Bind(typeof(IConfigurationService)).To(typeof(ConfigurationService));
            //Bind(typeof(DatabaseContext)).To(typeof(DatabaseContext));
            //Bind(typeof(IDocumentService)).To(typeof(DocumentService));
            //Bind(typeof(IPageService)).To(typeof(PageService));
            //Bind(typeof(ILotesService)).To(typeof(LotesService));
            //Bind(typeof(IPluginDefaultService)).To(typeof(PluginDefaultService));
            //Bind(typeof(IOutputProcessService)).To(typeof(OutputProcessService));
            //Bind(typeof(IBatchOutputProcessService)).To(typeof(BatchOutputProcessService));
            //Bind(typeof(IAppConfigService)).To(typeof(AppConfigService));
            //Bind(typeof(API.Pika.Client)).To(typeof(API.Pika.Client)).InSingletonScope();
            //Bind(typeof(EOSCameraController)).To(typeof(EOSCameraController));
            //Bind(typeof(FileSystemController)).To(typeof(FileSystemController));
            Bind(typeof(TWAINController)).To(typeof(TWAINController));

        }
    }
}
