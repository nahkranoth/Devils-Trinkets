using System.Collections.Generic;

namespace Hobscure.NPC { 
    public class NPCModel {

        public string name;

        public NPCCommandModel currentCommand;
        public List<NPCCommandModel> commands = new List<NPCCommandModel>();

    }
}