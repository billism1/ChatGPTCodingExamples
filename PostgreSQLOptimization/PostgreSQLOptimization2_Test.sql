create temp table if not exists table1(
	id uuid NOT NULL,
	casenumber integer NOT NULL,
	partnumber integer NOT NULL
);

create temp table if not exists table2(
	id uuid NOT NULL,
	casenumber integer NOT NULL,
	partnumber integer NOT NULL
);

insert into table1
(id, casenumber, partnumber)
values
(gen_random_uuid(), 1, 11),
(gen_random_uuid(), 2, 12),
(gen_random_uuid(), 3, 13),
(gen_random_uuid(), 4, 14);

insert into table2
(id, casenumber, partnumber)
values
(gen_random_uuid(), 4, 14),
(gen_random_uuid(), 5, 15);

-- Should yield count of 3
select count(t1.*)
from table1 t1
left outer join table2 t2
	on t1.casenumber=t2.casenumber
	and t1.partnumber=t2.partnumber
where t2.id is null;

-- ChatGPT's new query yields the same results:
SELECT 
  COUNT(*)
FROM table1 t1
WHERE NOT EXISTS (
  SELECT 1
  FROM table2 t2
  WHERE t2.casenumber = t1.casenumber
    AND t2.partnumber = t1.partnumber
);

drop table if exists table1;
drop table if exists table2;
