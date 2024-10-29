using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lenguaje
{
    public class Gramatica
    {
        public Gramatica()
        {
            DEC_INTEGER_ARGS();
            DEC_DECIMAL_ARGS();
            DEC_BOOLEAN_ARGS();
            DEC_TEXT_ARGS();
            DEC_CHAR_ARGS();
            DEC_CONDITION_ARGS();
            DEC_LOOP_ARGS();
            DEC_WHILST_ARGS();
            DEC_SELECT_ARGS();
            DEC_SENDBACK_ARGS();
            DEC_OPTION_ARGS();
            OPEN_DEC_ARGS();
            CLOSED_DEC_ARGS();
            SECURE_DEC_ARGS();
            FIXED_DEC_ARGS();
            DEC_CAPTURE_ARGS();
            DEC_DISPLAY_ARGS();
        }
        public Dictionary<string, HashSet<string>> GRAMATICA = new Dictionary<string, HashSet<string>>
    {
        // NUMERO
        {"COE1", new HashSet<string> {"ENTERO"}},
        {"CE05 COE1 CE06", new HashSet<string> {"ENTERO"}},

        {"CE05 COE1 CE03 COE1 CE06", new HashSet<string> {"DECIMAL"}},
        {"COE1 CE03 COE1", new HashSet<string> {"DECIMAL"}},

        // BOOLEANO
        {"BL01", new HashSet<string> {"BOOLEANO"}},
        {"CE05 BL01 CE06", new HashSet<string> {"BOOLEANO"}},
        {"BL02", new HashSet<string> {"BOOLEANO"}},
        {"CE05 BL02 CE06", new HashSet<string> {"BOOLEANO"}},

        //TEXT
        {"CE10 CD01 CE10", new HashSet<string> {"CADENA"}},
        {"CE10 CE10", new HashSet<string> {"CADENA"}},
        {"CE05 CADENA CE06", new HashSet<string> {"CADENA"}},

        //CHAR
        {"CE13 CR01 CE13", new HashSet<string> {"CARACTER"}},
        {"CE13 CE13", new HashSet<string> {"CARACTER"}},
        {"CE05 CARACTER CE06", new HashSet<string> {"CARACTER" }},

        // VARIABLES
        {"VAR1", new HashSet<string> {"VARIABLE_ENTERO"}},
        {"CE05 VAR1 CE06", new HashSet<string> {"VARIABLE_ENTERO"}},
        {"VAR2", new HashSet<string> {"VARIABLE_DECIMAL"}},
        {"CE05 VAR2 CE06", new HashSet<string> {"VARIABLE_DECIMAL"}},
        {"VAR3", new HashSet<string> {"VARIABLE_BOOLEANO"}},
        {"CE05 VAR3 CE06", new HashSet<string> {"VARIABLE_BOOLEANO"}},
        {"VAR4", new HashSet<string> {"VARIABLE_CADENA"}},
        {"CE05 VAR4 CE06", new HashSet<string> {"VARIABLE_CADENA"}},
        {"VAR5", new HashSet<string> {"VARIABLE_CHAR"}},
        {"CE05 VAR5 CE06", new HashSet<string> {"VARIABLE_CHAR"}},


       { "TPD01 ID01 CE11", new HashSet<string> { "DEC_INTEGER" } },

       { "TPD02 ID01 CE11", new HashSet<string> { "DEC_DECIMAL" } },

       { "TPD03 ID01 CE11", new HashSet<string> { "DEC_BOOLEAN" } },

       { "TPD04 ID01 CE11", new HashSet<string> { "DEC_TEXT" } },

       { "TPD05 ID01 CE11", new HashSet<string> { "DEC_CHAR" } },

       { "CE08", new HashSet<string> { "CORCHETE_ABIERTO" } },
       { "CORCHETE_ABIERTO", new HashSet<string> { "S"  } },
       { "CE09", new HashSet<string> { "CORCHETE_CERRADO" } },
       { "CORCHETE_CERRADO", new HashSet<string> { "S" } },

       { "PR02", new HashSet<string> { "OTHERWISE" } },
       { "OTHERWISE", new HashSet<string> { "S" } },

        { "PR05", new HashSet<string> { "PERFORM" } },
       { "PERFORM", new HashSet<string> { "S" } },

       { "PR08 CE11", new HashSet<string> { "STOP" } },
       { "STOP", new HashSet<string> { "S" } },

       { "PR10 CE12", new HashSet<string> { "STANDARD" } },
       { "STANDARD", new HashSet<string> { "S" } },

        { "PR11 CE11", new HashSet<string> { "PROCEED" } },
       { "PROCEED", new HashSet<string> { "S" } },

       { "CMT01", new HashSet<string> { "CARACTER_DE_COMENTARIO_DE_UNA_LINEA" } },
       { "CARACTER_DE_COMENTARIO_DE_UNA_LINEA", new HashSet<string> { "S" } },

       { "CMT02", new HashSet<string> { "CARACTER_DE_COMENTARIO_DE_VARIAS_LINEAS" } },
       { "CARACTER_DE_COMENTARIO_DE_VARIAS_LINEAS", new HashSet<string> { "S" } },


       { "CARACTER_DE_COMENTARIO_DE_UNA_LINEA CCT01", new HashSet<string> { "COMENTARIO_DE_UNA_LINEA" } },
       { "COMENTARIO_DE_UNA_LINEA", new HashSet<string> { "S" } },

        { "CARACTER_DE_COMENTARIO_DE_VARIAS_LINEAS CCT01", new HashSet<string> { "APERTURA_DE_COMENTARIO_DE_VARIAS_LINEAS" } },
       { "APERTURA_DE_COMENTARIO_DE_VARIAS_LINEAS", new HashSet<string> { "S" } },

       { "CCT01", new HashSet<string> { "CONTENIDO_COMENTARIO" } },
       { "CONTENIDO_COMENTARIO", new HashSet<string> { "S" } },

        { "CCT01 CARACTER_DE_COMENTARIO_DE_VARIAS_LINEAS", new HashSet<string> { "CIERRE_DE_COMENTARIO_DE_VARIAS_LINEAS" } },
       { "CIERRE_DE_COMENTARIO_DE_VARIAS_LINEAS", new HashSet<string> { "S" } },

        { "PR16", new HashSet<string> { "INICIO" } },
       { "INICIO", new HashSet<string> { "S" } },

       { "PR17", new HashSet<string> { "FIN" } },
       { "FIN", new HashSet<string> { "S" } },

       

        // OPERACIONES ARITMETICAS Y LÓGICAS
        {"OA01", new HashSet<string> {"OA"}},
        {"OA02", new HashSet<string> {"OA"}},
        {"OA03", new HashSet<string> {"OA"}},
        {"OA04", new HashSet<string> {"OA"}},
        {"OA05", new HashSet<string> {"OA"}},
       

        {"OR01", new HashSet<string> {"OR"}},
        {"OR02", new HashSet<string> {"OR"}},
        {"OR03", new HashSet<string> {"OR"}},
        {"OR04", new HashSet<string> {"OR"}},
        {"OR05", new HashSet<string> {"OR"}},
        {"OR06", new HashSet<string> {"OR"}},
        {"OR07", new HashSet<string> {"OR"}},

        {"OL01", new HashSet<string> {"OL"}},
        {"OL02", new HashSet<string> {"OL"}},
        {"OL03", new HashSet<string> {"OL"}},

       {"CE05 OPA CE06", new HashSet<string> {"OPA"}},
       {"CE05 OPR CE06", new HashSet<string> {"OPR"}},
       {"CE05 OPL CE06", new HashSet<string> {"OPR"}},


    };

        public void DEC_INTEGER_ARGS()
        {
           

            // Define rules for TPD01 and OAI operations
            var numRules = new string[] { "ENTERO", "VARIABLE_ENTERO", "NL01" };
            
                foreach (var numRule in numRules)
                {
                    AddRuleIfNotExists($"TPD01 ID01 CE07 {numRule} CE11", new HashSet<string> { "DEC_INTEGER" });
                }

            AddRuleIfNotExists($"TPD01 ID01 CE07 OPA CE11", new HashSet<string> { "DEC_INTEGER" });

            var operationRules = new string[] { "ENTERO", "VARIABLE_ENTERO" };
            for (int i = 1; i <= 7; i++)
            {
                foreach (var numRule in operationRules)
                {
                    AddRuleIfNotExists($"{numRule} OA0{i} {numRule}", new HashSet<string> { "OPA" });
                }
            }

            // Add the DEC_INTEGER rule if it doesn't exist
            AddRuleIfNotExists("DEC_INTEGER", new HashSet<string> { "S" });
        }
        public void DEC_DECIMAL_ARGS()
        {
            

            // Define rules for TPD01 and OAI operations
            var numRules = new string[] { "ENTERO", "VARIABLE_ENTERO","DECIMAL", "VARIABLE_DECIMAL", "NL01","OPA" };

            foreach (var numRule in numRules)
            {
                AddRuleIfNotExists($"TPD02 ID01 CE07 {numRule} CE11", new HashSet<string> { "DEC_DECIMAL" });
            }


            var operationRules = new string[] {"ENTERO", "VARIABLE_ENTERO", "DECIMAL", "VARIABLE_DECIMAL" };
            for (int i = 1; i <= 7; i++)
            {
                foreach (var numRule in operationRules)
                {
                    AddRuleIfNotExists($"{numRule} OA0{i} {numRule}", new HashSet<string> { "OPA" });
                }
            }

            // Add the DEC_INTEGER rule if it doesn't exist
            AddRuleIfNotExists("DEC_DECIMAL", new HashSet<string> { "S" });
        }

        public void DEC_BOOLEAN_ARGS()
        {


            // Define rules for TPD01 and OAI operations
            var numRules = new string[] { "BL01", "BL02", "OPL", "OPR", "NL01", "VARIABLE_BOOLEANO" };

            foreach (var numRule in numRules)
            {
                AddRuleIfNotExists($"TPD03 ID01 CE07 {numRule} CE11", new HashSet<string> { "DEC_BOOLEAN" });
            }

            

         

            var operationOPR = new string[] { "ENTERO", "VARIABLE_ENTERO", "DECIMAL", "VARIABLE_DECIMAL" };
            for (int i = 1; i <= 6; i++)
            {
                foreach (var numRule in operationOPR)
                {
                    AddRuleIfNotExists($"{numRule} OR0{i} {numRule}", new HashSet<string> { "OPR" });
                }
            }

            var operationOPL = new string[] { "OPR", "OPL" };
            for (int i = 1; i <= 3; i++)
            {
                foreach (var numRule in operationOPL)
                {
                    AddRuleIfNotExists($"{numRule} OL0{i} {numRule}", new HashSet<string> { "OPL" });
                }
            }


            // Add the DEC_INTEGER rule if it doesn't exist
            AddRuleIfNotExists("DEC_BOOLEAN", new HashSet<string> { "S" });
        }

        public void DEC_TEXT_ARGS()
        {


            // Define rules for TPD01 and OAI operations
            var numRules = new string[] { "CADENA", "VARIABLE_CADENA", "NL01" };

            foreach (var numRule in numRules)
            {
                AddRuleIfNotExists($"TPD04 ID01 CE07 {numRule} CE11", new HashSet<string> { "DEC_TEXT" });
            }


            // Add the DEC_INTEGER rule if it doesn't exist
            AddRuleIfNotExists("DEC_TEXT", new HashSet<string> { "S" });
        }

        public void DEC_CHAR_ARGS()
        {


            // Define rules for TPD01 and OAI operations
            var numRules = new string[] { "CARACTER", "VARIABLE_CHAR", "NL01" };

            foreach (var numRule in numRules)
            {
                AddRuleIfNotExists($"TPD05 ID01 CE07 {numRule} CE11", new HashSet<string> { "DEC_CHAR" });
            }


            // Add the DEC_INTEGER rule if it doesn't exist
            AddRuleIfNotExists("DEC_CHAR", new HashSet<string> { "S" });
        }

        public void DEC_CONDITION_ARGS()
        {


            // Define rules for TPD01 and OAI operations
            var numRules = new string[] { "OPR", "OPL"};

            foreach (var numRule in numRules)
            {
                AddRuleIfNotExists($"PR01 CE05 {numRule} CE06", new HashSet<string> { "CONDITION" });
            }


            // Add the DEC_INTEGER rule if it doesn't exist
            AddRuleIfNotExists("CONDITION", new HashSet<string> { "S" });
        }

        public void DEC_LOOP_ARGS()
        {
            //
            var VARRules = new string[] { "VAR1", "VAR2" };
            var INCDECRules = new string[] { "OA06", "OA07" };
            foreach (var miVARRules in VARRules)
            {
                foreach (var miINCDECRules in INCDECRules)
                {
                    AddRuleIfNotExists($"{miVARRules} {miINCDECRules} CE11", new HashSet<string> { "INCDEC" });
                }

            }

            // Define rules for TPD01 and OAI operations
            var OPRules = new string[] { "OPR", "OPL" };
            var DECRules = new string[] { "DEC_INTEGER", "DEC_DECIMAL" };

            foreach (var miDECRules in DECRules)
            {
                foreach (var miOPRules in OPRules)
                {
                    AddRuleIfNotExists($"PR03 CE05 {miDECRules} {miOPRules} CE11 INCDEC CE06", new HashSet<string> { "LOOP" });
                }
                
            }


            // Add the DEC_INTEGER rule if it doesn't exist
            AddRuleIfNotExists("LOOP", new HashSet<string> { "S" });
        }

        public void DEC_WHILST_ARGS()
        {
          
            // Define rules for TPD01 and OAI operations
            var OPRules = new string[] { "OPR", "OPL" };
           

          
                foreach (var miOPRules in OPRules)
                {
                    AddRuleIfNotExists($"PR04 CE05 {miOPRules} CE06", new HashSet<string> { "WHILST" });
                }

            


            // Add the DEC_INTEGER rule if it doesn't exist
            AddRuleIfNotExists("WHILST", new HashSet<string> { "S" });
        }

        public void DEC_SELECT_ARGS()
        {

            // Define rules for TPD01 and OAI operations
            var Rules = new string[] { "ENTERO","VARIABLE_ENTERO", "DECIMAL", "VARIABLE_DECIMAL", "CARACTER", "VARIABLE_CHAR","CADENA", "VARIABLE_CADENA" };
           


            foreach (var miRules in Rules)
            {
                AddRuleIfNotExists($"PR06 {miRules}", new HashSet<string> { "SELECT" });
            }

          


                // Add the DEC_INTEGER rule if it doesn't exist
                AddRuleIfNotExists("SELECT", new HashSet<string> { "S" });
        }

        public void DEC_SENDBACK_ARGS()
        {

           
            // Define rules for TPD01 and OAI operations
            var Rules = new string[] { "ENTERO", "VARIABLE_ENTERO", "DECIMAL", "VARIABLE_DECIMAL", "CARACTER", "VARIABLE_CHAR", "CADENA", "VARIABLE_CADENA","OPR","OPL","OPA","NL01","BL01", "BL02" };
            var numRules = new string[] { "ENTERO", "VARIABLE_ENTERO", "DECIMAL", "VARIABLE_DECIMAL" };


            foreach (var miRules in Rules)
            {
                AddRuleIfNotExists($"PR07 {miRules} CE11", new HashSet<string> { "SENDBACK" });
            }

            foreach (var minumRules in numRules)
            {
                AddRuleIfNotExists($"OPA OA {minumRules}", new HashSet<string> { "OPA" });
            }


            // Add the DEC_INTEGER rule if it doesn't exist
            AddRuleIfNotExists("SENDBACK", new HashSet<string> { "S" });
        }

        public void DEC_OPTION_ARGS()
        {

            // Define rules for TPD01 and OAI operations
            var Rules = new string[] { "ENTERO", "DECIMAL", "CARACTER", "CADENA" };
            


            foreach (var miRules in Rules)
            {
                AddRuleIfNotExists($"PR09 {miRules} CE12", new HashSet<string> { "OPTION" });
            }

            


            // Add the DEC_INTEGER rule if it doesn't exist
            AddRuleIfNotExists("OPTION", new HashSet<string> { "S" });
        }

        public void OPEN_DEC_ARGS()
        {

            // Define rules for TPD01 and OAI operations
            var Rules = new string[] { "DEC_INTEGER", "DEC_DECIMAL", "DEC_BOOLEAN", "DEC_TEXT" , "DEC_CHAR" };



            foreach (var miRules in Rules)
            {
                AddRuleIfNotExists($"PR12 {miRules}", new HashSet<string> { "OPEN_DEC" });
            }




            // Add the DEC_INTEGER rule if it doesn't exist
            AddRuleIfNotExists("OPEN_DEC", new HashSet<string> { "S" });
        }

        public void CLOSED_DEC_ARGS()
        {

            // Define rules for TPD01 and OAI operations
            var Rules = new string[] { "DEC_INTEGER", "DEC_DECIMAL", "DEC_BOOLEAN", "DEC_TEXT", "DEC_CHAR" };



            foreach (var miRules in Rules)
            {
                AddRuleIfNotExists($"PR13 {miRules}", new HashSet<string> { "CLOSED_DEC" });
            }




            // Add the DEC_INTEGER rule if it doesn't exist
            AddRuleIfNotExists("CLOSED_DEC", new HashSet<string> { "S" });
        }

        public void SECURE_DEC_ARGS()
        {

            // Define rules for TPD01 and OAI operations
            var Rules = new string[] { "DEC_INTEGER", "DEC_DECIMAL", "DEC_BOOLEAN", "DEC_TEXT", "DEC_CHAR" };



            foreach (var miRules in Rules)
            {
                AddRuleIfNotExists($"PR14 {miRules}", new HashSet<string> { "SECURE_DEC" });
            }




            // Add the DEC_INTEGER rule if it doesn't exist
            AddRuleIfNotExists("SECURE_DEC", new HashSet<string> { "S" });
        }

        public void FIXED_DEC_ARGS()
        {

            // Define rules for TPD01 and OAI operations
            var Rules = new string[] { "DEC_INTEGER", "DEC_DECIMAL", "DEC_BOOLEAN", "DEC_TEXT", "DEC_CHAR" };



            foreach (var miRules in Rules)
            {
                AddRuleIfNotExists($"PR15 {miRules}", new HashSet<string> { "FIXED_DEC" });
            }




            // Add the DEC_INTEGER rule if it doesn't exist
            AddRuleIfNotExists("FIXED_DEC", new HashSet<string> { "S" });
        }

        public void DEC_CAPTURE_ARGS()
        {


            // Define rules for TPD01 and OAI operations
            var Rules = new string[] { "ENTERO", "VARIABLE_ENTERO", "DECIMAL", "VARIABLE_DECIMAL", "CARACTER", "VARIABLE_CHAR", "CADENA", "VARIABLE_CADENA", "OPR", "OPL", "OPA", "NL01", "BL01", "BL02" };
            


            foreach (var miRules in Rules)
            {
                AddRuleIfNotExists($"CAP01 {miRules} CE11", new HashSet<string> { "CAPTURE" });
            }

          

            // Add the DEC_INTEGER rule if it doesn't exist
            AddRuleIfNotExists("CAPTURE", new HashSet<string> { "S" });
        }

        public void DEC_DISPLAY_ARGS()
        {


            // Define rules for TPD01 and OAI operations
            var Rules = new string[] { "ENTERO", "VARIABLE_ENTERO", "DECIMAL", "VARIABLE_DECIMAL", "CARACTER", "VARIABLE_CHAR", "CADENA", "VARIABLE_CADENA", "OPR", "OPL", "OPA", "NL01", "BL01", "BL02" };



            foreach (var miRules in Rules)
            {
                AddRuleIfNotExists($"LT01 {miRules} CE11", new HashSet<string> { "DISPLAY" });
            }



            // Add the DEC_INTEGER rule if it doesn't exist
            AddRuleIfNotExists("DISPLAY", new HashSet<string> { "S" });
        }

        // Helper method to add rules if they do not already exist
        private void AddRuleIfNotExists(string rule, HashSet<string> values)
        {
            if (!GRAMATICA.ContainsKey(rule)) // Check if the rule already exists
            {
                GRAMATICA.Add(rule, values);
            }
        }


        public Dictionary<string, HashSet<string>> ObtenerGrammatica()
        {
            return GRAMATICA;

           
        }
    }
}
