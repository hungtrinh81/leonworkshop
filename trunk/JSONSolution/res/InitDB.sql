CREATE TABLE Computer (uid VARCHAR(32) PRIMARY KEY, Owner VARCHAR(32), HostName VARCHAR(32), CPU VARCHAR(16), RAM VARCHAR(16), Cost INTEGER);
go

INSERT INTO Computer (uid, Owner, HostName, CPU, RAM, Cost) VALUES ('c219e63b6ae54cb18cb3799301a05faa', 'Leon', 'FreeHome', '1.0GHz', '684MB', 36000);
INSERT INTO Computer (uid, Owner, HostName, CPU, RAM, Cost) VALUES ('b4b981f4733048c19eca8a684d384381', 'Leon', 'XP1600', '1.6GHz', '512MB', 30000);
INSERT INTO Computer (uid, Owner, HostName, CPU, RAM, Cost) VALUES ('26b8a69699a2485fb8e47fe53b0bf79b', 'Leon', 'FreeCell', '2.6GHz', '1.5GB', 25000);
INSERT INTO Computer (uid, Owner, HostName, CPU, RAM, Cost) VALUES ('f87c541edb154f41a8ff441812699693', 'Leon', 'Leon-Chuang', '1.8GHz', '1.0GB', 45000);

INSERT INTO Computer (uid, Owner, HostName, CPU, RAM, Cost) VALUES ('031465dd4e6341499bdeb951c014a180', 'Matt', 'Matt_Yeh', '2.6GHz', '2.0GB', 31000);
INSERT INTO Computer (uid, Owner, HostName, CPU, RAM, Cost) VALUES ('db5135e8abe84008aa1f8a2b0e1be78b', 'Allen', 'Allen_NB', '2.0GHz', '1.0GB', 43000);
go