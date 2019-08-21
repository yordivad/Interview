
CREATE SEQUENCE user_seq AS BIGINT;

CREATE TABLE  "user"  (
    id          BIGINT  DEFAULT nextval('user_seq') PRIMARY KEY,
    name        VARCHAR(200),
    lastname    VARCHAR(200),
    email       VARCHAR(200) NOT NULL UNIQUE,
    password    VARCHAR(500) NOT NULL
);
