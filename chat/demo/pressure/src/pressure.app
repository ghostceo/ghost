{application, pressure, [
    {description, "Pressure test tool"},
    {vsn, "0.0"},
    {modules, []},
    {registered, []},
    {applications, [kernel, stdlib]},
    {env, [
    	{host, "192.168.142.119"},
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