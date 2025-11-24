using System.Collections.Generic;

namespace GDTKernel_Interprete.Semantico.Validaciones
{
    public static class Validadores
    {
        private static readonly List<IValidadorBloque> _validadores = new List<IValidadorBloque>()
        {
            new ValidadorDefault(),
            new ValidadorLog(),
            new ValidadorLoop(),
            new ValidadorFire(),
            new ValidadorThread(),
            new ValidadorInvoke(),
            new ValidadorDB(),

            new ValidadorKill(),
            new ValidadorCopy(),
            new ValidadorDel(),
            new ValidadorMkdir(),
            new ValidadorFa(),

            new ValidadorExe(),
            new ValidadorSql(),
            new ValidadorForeach(),
            new ValidadorIf(),
            new ValidadorKey(),
            new ValidadorReg(),
            new ValidadorParam(),
            new ValidadorEx(),
        };

        public static List<IValidadorBloque> ObtnerValidadores()
        {
            return _validadores;
        }
    }
}
