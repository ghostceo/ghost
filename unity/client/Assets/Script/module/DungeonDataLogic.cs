using UnityEngine;
using System.Collections;

public class DungeonDataLogic
{
    private static DungeonDataLogic instance;
    public static DungeonDataLogic ins
    {
        get
        {
            if(instance == null)
                instance = new DungeonDataLogic();
            return instance;
        }
    }
    private DungeonDataLogic()
    {

    }
    public void Init()
    {

    }
	
}
