	
CREATE SCHEMA social;

CREATE SEQUENCE social.seq_config AS BIGINT;

CREATE TABLE social.config
(
    id BIGINT  DEFAULT nextval('social.seq_config') PRIMARY KEY,
    server VARCHAR(100)
)

CREATE TABLE social.setting
(
    userId BIGINT NOT NULL,
    email VARCHAR(200)
);

CREATE TABLE social.message
(
    email_id UUID,
    userId BIGINT NOT NULL,
    subject VARCHAR(100),
    body VARCHAR(2000)
)
