{application, pressure, [
    {description, "Pressure test tool"},
    {vsn, "0.0"},
    {modules, []},
    {registered, []},
    {applications, [kernel, stdlib]},
    {env, [
    	{host, "localhost"},
    	{port, 9320},
        {load, 10},  % 每个场景的人数
    	{scenes, [
    		% {1000, 3500, 2200},
    		% {1000, 3500, 2200},
    		% {1000, 3500, 2200},
    		% {1000, 3500, 2200},
    		% {1000, 3500, 2200},
    		% {1000, 3500, 2200},
    		% {1000, 3500, 2200},
    		% {1000, 3500, 2200},
    		% {1000, 3500, 2200},
    		{1000, 3500, 2200}
    	]}
    ]},
    {mod, {pressure_app, []}}
]}.