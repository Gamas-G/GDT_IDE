namespace GDTKernel_Util.GenScript
{
    public interface IGenScript
    {
        void GenScriptAdd(string reglas, string tipo, string UseSibItem);
        void GenScriptUpdate(string reglas, string tipo, string UseSibItem);
        void GenScriptDelete(string reglas, string tipo, string UseSibItem);
    }
}
