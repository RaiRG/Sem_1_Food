--
-- PostgreSQL database dump
--

-- Dumped from database version 12.4
-- Dumped by pg_dump version 12.4

-- Started on 2020-12-19 20:21:55

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 215 (class 1259 OID 33259)
-- Name: bookmarks; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.bookmarks (
    dish_id integer NOT NULL,
    client_id integer NOT NULL
);


ALTER TABLE public.bookmarks OWNER TO postgres;

--
-- TOC entry 205 (class 1259 OID 25042)
-- Name: order_of; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.order_of
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.order_of OWNER TO postgres;

--
-- TOC entry 206 (class 1259 OID 25044)
-- Name: clients; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.clients (
    id integer DEFAULT nextval('public.order_of'::regclass),
    name character varying(100),
    surname character varying(100),
    login character varying(100),
    img character varying(100)
);


ALTER TABLE public.clients OWNER TO postgres;

--
-- TOC entry 203 (class 1259 OID 16544)
-- Name: databasechangelog; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.databasechangelog (
    id character varying(255) NOT NULL,
    author character varying(255) NOT NULL,
    filename character varying(255) NOT NULL,
    dateexecuted timestamp without time zone NOT NULL,
    orderexecuted integer NOT NULL,
    exectype character varying(10) NOT NULL,
    md5sum character varying(35),
    description character varying(255),
    comments character varying(255),
    tag character varying(255),
    liquibase character varying(20),
    contexts character varying(255),
    labels character varying(255),
    deployment_id character varying(10)
);


ALTER TABLE public.databasechangelog OWNER TO postgres;

--
-- TOC entry 202 (class 1259 OID 16539)
-- Name: databasechangeloglock; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.databasechangeloglock (
    id integer NOT NULL,
    locked boolean NOT NULL,
    lockgranted timestamp without time zone,
    lockedby character varying(255)
);


ALTER TABLE public.databasechangeloglock OWNER TO postgres;

--
-- TOC entry 204 (class 1259 OID 16550)
-- Name: department; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.department (
    id integer NOT NULL,
    name character varying(50) NOT NULL,
    actice integer DEFAULT 1,
    country character varying(2)
);


ALTER TABLE public.department OWNER TO postgres;

--
-- TOC entry 209 (class 1259 OID 25072)
-- Name: dish_client; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.dish_client (
    dish_id integer NOT NULL,
    client_id integer
);


ALTER TABLE public.dish_client OWNER TO postgres;

--
-- TOC entry 214 (class 1259 OID 33251)
-- Name: dish_kitchen; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.dish_kitchen (
    dish_id integer NOT NULL,
    kitchen_id integer NOT NULL
);


ALTER TABLE public.dish_kitchen OWNER TO postgres;

--
-- TOC entry 211 (class 1259 OID 25082)
-- Name: dish_product; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.dish_product (
    dish_id integer,
    product_id integer
);


ALTER TABLE public.dish_product OWNER TO postgres;

--
-- TOC entry 208 (class 1259 OID 25064)
-- Name: dishes; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.dishes (
    id integer NOT NULL,
    name character varying(400),
    cooktime time without time zone,
    portions integer,
    cookingmethod text,
    img character varying(100),
    creatingdate timestamp without time zone
);


ALTER TABLE public.dishes OWNER TO postgres;

--
-- TOC entry 216 (class 1259 OID 33270)
-- Name: forum; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.forum (
    id integer NOT NULL,
    client_id integer,
    message text,
    send_date_time timestamp without time zone
);


ALTER TABLE public.forum OWNER TO postgres;

--
-- TOC entry 207 (class 1259 OID 25051)
-- Name: personalinfo; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.personalinfo (
    id integer NOT NULL,
    mail character varying(200),
    hashpassword character varying(500)
);


ALTER TABLE public.personalinfo OWNER TO postgres;

--
-- TOC entry 210 (class 1259 OID 25077)
-- Name: products; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.products (
    id integer NOT NULL,
    name character varying(150)
);


ALTER TABLE public.products OWNER TO postgres;

--
-- TOC entry 213 (class 1259 OID 25107)
-- Name: reviews; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.reviews (
    dish_id integer NOT NULL,
    client_id integer NOT NULL,
    description text NOT NULL,
    id integer NOT NULL,
    send_date_time timestamp without time zone
);


ALTER TABLE public.reviews OWNER TO postgres;

--
-- TOC entry 212 (class 1259 OID 25085)
-- Name: steps; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.steps (
    dishid integer NOT NULL,
    numberofstep integer NOT NULL,
    description text,
    img character varying(100)
);


ALTER TABLE public.steps OWNER TO postgres;

--
-- TOC entry 2909 (class 0 OID 33259)
-- Dependencies: 215
-- Data for Name: bookmarks; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.bookmarks (dish_id, client_id) VALUES (2, 0);
INSERT INTO public.bookmarks (dish_id, client_id) VALUES (7, 0);
INSERT INTO public.bookmarks (dish_id, client_id) VALUES (1, 0);
INSERT INTO public.bookmarks (dish_id, client_id) VALUES (0, 1);
INSERT INTO public.bookmarks (dish_id, client_id) VALUES (3, 1);
INSERT INTO public.bookmarks (dish_id, client_id) VALUES (1, 1);
INSERT INTO public.bookmarks (dish_id, client_id) VALUES (2, 1);
INSERT INTO public.bookmarks (dish_id, client_id) VALUES (5, 1);
INSERT INTO public.bookmarks (dish_id, client_id) VALUES (11, 1);
INSERT INTO public.bookmarks (dish_id, client_id) VALUES (12, 1);
INSERT INTO public.bookmarks (dish_id, client_id) VALUES (13, 1);
INSERT INTO public.bookmarks (dish_id, client_id) VALUES (15, 1);
INSERT INTO public.bookmarks (dish_id, client_id) VALUES (16, 1);
INSERT INTO public.bookmarks (dish_id, client_id) VALUES (6, 1);
INSERT INTO public.bookmarks (dish_id, client_id) VALUES (7, 1);
INSERT INTO public.bookmarks (dish_id, client_id) VALUES (8, 1);
INSERT INTO public.bookmarks (dish_id, client_id) VALUES (17, 1);
INSERT INTO public.bookmarks (dish_id, client_id) VALUES (14, 1);
INSERT INTO public.bookmarks (dish_id, client_id) VALUES (10, 1);
INSERT INTO public.bookmarks (dish_id, client_id) VALUES (9, 1);
INSERT INTO public.bookmarks (dish_id, client_id) VALUES (18, 1);
INSERT INTO public.bookmarks (dish_id, client_id) VALUES (1, 2);
INSERT INTO public.bookmarks (dish_id, client_id) VALUES (20, 2);
INSERT INTO public.bookmarks (dish_id, client_id) VALUES (20, 3);
INSERT INTO public.bookmarks (dish_id, client_id) VALUES (21, 3);
INSERT INTO public.bookmarks (dish_id, client_id) VALUES (0, 3);
INSERT INTO public.bookmarks (dish_id, client_id) VALUES (22, 3);


--
-- TOC entry 2900 (class 0 OID 25044)
-- Dependencies: 206
-- Data for Name: clients; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.clients (id, name, surname, login, img) VALUES (0, 'Раилина', 'Галиева', 'Ра', 'img/profilePhotos/20201216134840117unnamed.jpg');
INSERT INTO public.clients (id, name, surname, login, img) VALUES (3, 'Hfb', 'fasdasdf', 'Иван', 'img/profilePhotos/2020121614293524unnamed.jpg');
INSERT INTO public.clients (id, name, surname, login, img) VALUES (1, 'Петр', 'Иванов', 'Иванушка', 'img/profilePhotos/202012162033561Без названия.jfif');
INSERT INTO public.clients (id, name, surname, login, img) VALUES (2, 'Тест', 'Тест', 'Тест', 'img/default.png');


--
-- TOC entry 2897 (class 0 OID 16544)
-- Dependencies: 203
-- Data for Name: databasechangelog; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.databasechangelog (id, author, filename, dateexecuted, orderexecuted, exectype, md5sum, description, comments, tag, liquibase, contexts, labels, deployment_id) VALUES ('1', 'your.name', 'C:/Users/Railina/LiquibasePostgreSQL/dbchangelog.sql', '2020-09-25 14:10:34.497264', 1, 'EXECUTED', '8:635487a6bf1be543ff7d1de3cb1bb5e2', 'sql', '', NULL, '3.10.2', NULL, NULL, '1032234226');
INSERT INTO public.databasechangelog (id, author, filename, dateexecuted, orderexecuted, exectype, md5sum, description, comments, tag, liquibase, contexts, labels, deployment_id) VALUES ('2', 'your.name', 'C:/Users/Railina/LiquibasePostgreSQL/dbchangelog.sql', '2020-09-25 14:10:34.645594', 2, 'EXECUTED', '8:0288014236df70e5c2fe6be05e94aeda', 'sql', '', NULL, '3.10.2', NULL, NULL, '1032234226');
INSERT INTO public.databasechangelog (id, author, filename, dateexecuted, orderexecuted, exectype, md5sum, description, comments, tag, liquibase, contexts, labels, deployment_id) VALUES ('3', 'other.dev', 'C:/Users/Railina/LiquibasePostgreSQL/dbchangelog.sql', '2020-09-25 14:10:34.649198', 3, 'EXECUTED', '8:139797c40dad1d135ed16884663ba044', 'sql', '', NULL, '3.10.2', NULL, NULL, '1032234226');


--
-- TOC entry 2896 (class 0 OID 16539)
-- Dependencies: 202
-- Data for Name: databasechangeloglock; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.databasechangeloglock (id, locked, lockgranted, lockedby) VALUES (1, false, NULL, NULL);


--
-- TOC entry 2898 (class 0 OID 16550)
-- Dependencies: 204
-- Data for Name: department; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 2903 (class 0 OID 25072)
-- Dependencies: 209
-- Data for Name: dish_client; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.dish_client (dish_id, client_id) VALUES (0, 0);
INSERT INTO public.dish_client (dish_id, client_id) VALUES (1, 0);
INSERT INTO public.dish_client (dish_id, client_id) VALUES (2, 0);
INSERT INTO public.dish_client (dish_id, client_id) VALUES (3, 0);
INSERT INTO public.dish_client (dish_id, client_id) VALUES (4, 0);
INSERT INTO public.dish_client (dish_id, client_id) VALUES (5, 0);
INSERT INTO public.dish_client (dish_id, client_id) VALUES (6, 0);
INSERT INTO public.dish_client (dish_id, client_id) VALUES (7, 0);
INSERT INTO public.dish_client (dish_id, client_id) VALUES (8, 0);
INSERT INTO public.dish_client (dish_id, client_id) VALUES (9, 0);
INSERT INTO public.dish_client (dish_id, client_id) VALUES (10, 0);
INSERT INTO public.dish_client (dish_id, client_id) VALUES (11, 0);
INSERT INTO public.dish_client (dish_id, client_id) VALUES (12, 0);
INSERT INTO public.dish_client (dish_id, client_id) VALUES (13, 0);
INSERT INTO public.dish_client (dish_id, client_id) VALUES (14, 0);
INSERT INTO public.dish_client (dish_id, client_id) VALUES (15, 0);
INSERT INTO public.dish_client (dish_id, client_id) VALUES (16, 0);
INSERT INTO public.dish_client (dish_id, client_id) VALUES (17, 0);
INSERT INTO public.dish_client (dish_id, client_id) VALUES (18, 1);
INSERT INTO public.dish_client (dish_id, client_id) VALUES (19, 2);
INSERT INTO public.dish_client (dish_id, client_id) VALUES (20, 3);
INSERT INTO public.dish_client (dish_id, client_id) VALUES (21, 3);
INSERT INTO public.dish_client (dish_id, client_id) VALUES (22, 3);
INSERT INTO public.dish_client (dish_id, client_id) VALUES (23, 3);


--
-- TOC entry 2908 (class 0 OID 33251)
-- Dependencies: 214
-- Data for Name: dish_kitchen; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.dish_kitchen (dish_id, kitchen_id) VALUES (0, -1);
INSERT INTO public.dish_kitchen (dish_id, kitchen_id) VALUES (1, -1);
INSERT INTO public.dish_kitchen (dish_id, kitchen_id) VALUES (2, -1);
INSERT INTO public.dish_kitchen (dish_id, kitchen_id) VALUES (3, -2);
INSERT INTO public.dish_kitchen (dish_id, kitchen_id) VALUES (4, -3);
INSERT INTO public.dish_kitchen (dish_id, kitchen_id) VALUES (5, -1);
INSERT INTO public.dish_kitchen (dish_id, kitchen_id) VALUES (6, -2);
INSERT INTO public.dish_kitchen (dish_id, kitchen_id) VALUES (7, -2);
INSERT INTO public.dish_kitchen (dish_id, kitchen_id) VALUES (8, -2);
INSERT INTO public.dish_kitchen (dish_id, kitchen_id) VALUES (9, -3);
INSERT INTO public.dish_kitchen (dish_id, kitchen_id) VALUES (10, -3);
INSERT INTO public.dish_kitchen (dish_id, kitchen_id) VALUES (11, -3);
INSERT INTO public.dish_kitchen (dish_id, kitchen_id) VALUES (11, -2);
INSERT INTO public.dish_kitchen (dish_id, kitchen_id) VALUES (11, -1);
INSERT INTO public.dish_kitchen (dish_id, kitchen_id) VALUES (12, -1);
INSERT INTO public.dish_kitchen (dish_id, kitchen_id) VALUES (13, -3);
INSERT INTO public.dish_kitchen (dish_id, kitchen_id) VALUES (13, -2);
INSERT INTO public.dish_kitchen (dish_id, kitchen_id) VALUES (13, -1);
INSERT INTO public.dish_kitchen (dish_id, kitchen_id) VALUES (14, -3);
INSERT INTO public.dish_kitchen (dish_id, kitchen_id) VALUES (14, -2);
INSERT INTO public.dish_kitchen (dish_id, kitchen_id) VALUES (14, -1);
INSERT INTO public.dish_kitchen (dish_id, kitchen_id) VALUES (15, -3);
INSERT INTO public.dish_kitchen (dish_id, kitchen_id) VALUES (15, -2);
INSERT INTO public.dish_kitchen (dish_id, kitchen_id) VALUES (15, -1);
INSERT INTO public.dish_kitchen (dish_id, kitchen_id) VALUES (16, -1);
INSERT INTO public.dish_kitchen (dish_id, kitchen_id) VALUES (17, -2);
INSERT INTO public.dish_kitchen (dish_id, kitchen_id) VALUES (18, -1);
INSERT INTO public.dish_kitchen (dish_id, kitchen_id) VALUES (19, -2);
INSERT INTO public.dish_kitchen (dish_id, kitchen_id) VALUES (20, -3);
INSERT INTO public.dish_kitchen (dish_id, kitchen_id) VALUES (20, -2);
INSERT INTO public.dish_kitchen (dish_id, kitchen_id) VALUES (20, -1);
INSERT INTO public.dish_kitchen (dish_id, kitchen_id) VALUES (21, -3);
INSERT INTO public.dish_kitchen (dish_id, kitchen_id) VALUES (21, -2);
INSERT INTO public.dish_kitchen (dish_id, kitchen_id) VALUES (22, -2);
INSERT INTO public.dish_kitchen (dish_id, kitchen_id) VALUES (23, -3);
INSERT INTO public.dish_kitchen (dish_id, kitchen_id) VALUES (23, -2);
INSERT INTO public.dish_kitchen (dish_id, kitchen_id) VALUES (23, -1);


--
-- TOC entry 2905 (class 0 OID 25082)
-- Dependencies: 211
-- Data for Name: dish_product; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.dish_product (dish_id, product_id) VALUES (0, 0);
INSERT INTO public.dish_product (dish_id, product_id) VALUES (0, 1);
INSERT INTO public.dish_product (dish_id, product_id) VALUES (0, 2);
INSERT INTO public.dish_product (dish_id, product_id) VALUES (1, 3);
INSERT INTO public.dish_product (dish_id, product_id) VALUES (1, 4);
INSERT INTO public.dish_product (dish_id, product_id) VALUES (1, 2);
INSERT INTO public.dish_product (dish_id, product_id) VALUES (1, 5);
INSERT INTO public.dish_product (dish_id, product_id) VALUES (2, 6);
INSERT INTO public.dish_product (dish_id, product_id) VALUES (2, 7);
INSERT INTO public.dish_product (dish_id, product_id) VALUES (2, 8);
INSERT INTO public.dish_product (dish_id, product_id) VALUES (3, 9);
INSERT INTO public.dish_product (dish_id, product_id) VALUES (4, 9);
INSERT INTO public.dish_product (dish_id, product_id) VALUES (4, 4);
INSERT INTO public.dish_product (dish_id, product_id) VALUES (5, 4);
INSERT INTO public.dish_product (dish_id, product_id) VALUES (6, 10);
INSERT INTO public.dish_product (dish_id, product_id) VALUES (6, 11);
INSERT INTO public.dish_product (dish_id, product_id) VALUES (7, 10);
INSERT INTO public.dish_product (dish_id, product_id) VALUES (8, 10);
INSERT INTO public.dish_product (dish_id, product_id) VALUES (8, 4);
INSERT INTO public.dish_product (dish_id, product_id) VALUES (9, 10);
INSERT INTO public.dish_product (dish_id, product_id) VALUES (9, 11);
INSERT INTO public.dish_product (dish_id, product_id) VALUES (10, 12);
INSERT INTO public.dish_product (dish_id, product_id) VALUES (10, 11);
INSERT INTO public.dish_product (dish_id, product_id) VALUES (11, 13);
INSERT INTO public.dish_product (dish_id, product_id) VALUES (11, 11);
INSERT INTO public.dish_product (dish_id, product_id) VALUES (12, 10);
INSERT INTO public.dish_product (dish_id, product_id) VALUES (12, 14);
INSERT INTO public.dish_product (dish_id, product_id) VALUES (13, 10);
INSERT INTO public.dish_product (dish_id, product_id) VALUES (13, 4);
INSERT INTO public.dish_product (dish_id, product_id) VALUES (14, 10);
INSERT INTO public.dish_product (dish_id, product_id) VALUES (14, 4);
INSERT INTO public.dish_product (dish_id, product_id) VALUES (15, 10);
INSERT INTO public.dish_product (dish_id, product_id) VALUES (16, 10);
INSERT INTO public.dish_product (dish_id, product_id) VALUES (16, 11);
INSERT INTO public.dish_product (dish_id, product_id) VALUES (17, 10);
INSERT INTO public.dish_product (dish_id, product_id) VALUES (18, 15);
INSERT INTO public.dish_product (dish_id, product_id) VALUES (18, 11);
INSERT INTO public.dish_product (dish_id, product_id) VALUES (19, 10);
INSERT INTO public.dish_product (dish_id, product_id) VALUES (20, 16);
INSERT INTO public.dish_product (dish_id, product_id) VALUES (20, 17);
INSERT INTO public.dish_product (dish_id, product_id) VALUES (21, 10);
INSERT INTO public.dish_product (dish_id, product_id) VALUES (21, 11);
INSERT INTO public.dish_product (dish_id, product_id) VALUES (21, 18);
INSERT INTO public.dish_product (dish_id, product_id) VALUES (22, 10);
INSERT INTO public.dish_product (dish_id, product_id) VALUES (22, 11);
INSERT INTO public.dish_product (dish_id, product_id) VALUES (23, 10);
INSERT INTO public.dish_product (dish_id, product_id) VALUES (23, 11);
INSERT INTO public.dish_product (dish_id, product_id) VALUES (23, 18);
INSERT INTO public.dish_product (dish_id, product_id) VALUES (23, 5);


--
-- TOC entry 2902 (class 0 OID 25064)
-- Dependencies: 208
-- Data for Name: dishes; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.dishes (id, name, cooktime, portions, cookingmethod, img, creatingdate) VALUES (0, 'Кыстыбый', '01:00:00', 10, 'Кыстыбый — старинное традиционное татарское и башкирское блюдо из теста с начинкой. Представляет собой обжаренную пресную лепешку, начиненную чаще всего картофельным пюре или пшенной кашей.', 'img/food/20201216051553148.jpg', '2020-12-15 23:40:00');
INSERT INTO public.dishes (id, name, cooktime, portions, cookingmethod, img, creatingdate) VALUES (1, 'ЭЧПОЧМАК', '01:00:00', 10, 'Треугольные пирожки эчпочмаки с отверстием посередине, приготовленные из дрожжевого или пресного теста с бараниной, луком, картофелем и специями, чем-то напоминают самсу. ', 'img/food/20201216056552001.jfif', '2020-12-15 23:40:00');
INSERT INTO public.dishes (id, name, cooktime, portions, cookingmethod, img, creatingdate) VALUES (2, 'Баурсак', '20:00:00', 5, 'Баурсак – это традиционное блюдо казахской кухни, а также башкирской, татарской и других азиатских кухонь. Рецепт баурсаков несложен, это кусочки теста, жаренные во фритюре. Обычно баурсаки готовятся из пресного или дрожжевого теста, но есть и баурсаки, рецепт которых предлагает сделать их из творожного теста.', 'img/food/2020121611482721.jpg', '2020-12-15 23:42:00');
INSERT INTO public.dishes (id, name, cooktime, portions, cookingmethod, img, creatingdate) VALUES (3, 'Шурпа', '01:00:00', 10, 'Шурпа', 'img/food/202012161420708275_0124sau_1089_6hi.jpg', '2020-12-15 23:46:00');
INSERT INTO public.dishes (id, name, cooktime, portions, cookingmethod, img, creatingdate) VALUES (6, 'Пальчики оближешь', '04:00:00', 1, 'Вкусное блюдо', 'img/food/2020121611313775Без названия.jfif', '2020-12-15 01:40:00');
INSERT INTO public.dishes (id, name, cooktime, portions, cookingmethod, img, creatingdate) VALUES (7, 'Макароны', '04:00:00', 10, 'Описание блюда', 'img/food/2020121611453366content_658e095df63555e26dc8ca86ffd0b9e0.jpg', '2020-12-15 02:40:00');
INSERT INTO public.dishes (id, name, cooktime, portions, cookingmethod, img, creatingdate) VALUES (4, 'Беляши', '01:00:00', 8, 'Аппетитные, румяные и ароматные беляши из пышного теста с сочной мясной начинкой любят многие. Если вы хотите попробовать настоящие беляши, не приобретайте их на улице или в сомнительном кафе, приготовьте беляши дома, тем более это совсем не сложно.', 'img/default.png', '2020-12-15 23:49:00');
INSERT INTO public.dishes (id, name, cooktime, portions, cookingmethod, img, creatingdate) VALUES (5, 'Чак-чак', '00:00:00', 0, 'В этом рецепте мы научим вас готовить самую популярную восточную сладость – чак-чак. Рецепт чак-чака с медом в домашних условиях позволяет приготовить великолепное сладкое блюдо из пресного теста и ароматного меда.', 'img/food/202012161920781sm_249390.jpg', '2020-12-15 00:40:00');
INSERT INTO public.dishes (id, name, cooktime, portions, cookingmethod, img, creatingdate) VALUES (8, 'dsfsfda', '04:05:00', 1, 'Это блюдо для меня новое, никогда раньше не готовила. Мне казалось, что оно сложное в приготовлении, так как опыта в раскатывании лепешек у меня нет. Вот решила попробовать, и со второй лепешки все получилось. Очень надеюсь, что мое видео поможет новичкам замесить хорошее тесто и раскатать лепешки.  Начинку положила такую, какая была указана в рецепте.', 'img/food/2020121611629525Без названия.jfif', '2020-12-15 03:40:00');
INSERT INTO public.dishes (id, name, cooktime, portions, cookingmethod, img, creatingdate) VALUES (9, 'Название', '04:05:00', 2, 'Никогда раньше не готовила. Мне казалось, что оно сложное в приготовлении, так как опыта в раскатывании лепешек у меня нет. Вот решила попробовать, и со второй лепешки все получилось. Очень надеюсь, что мое видео поможет новичкам замесить хорошее тесто и раскатать лепешки.  Начинку положила такую, какая была указана в рецепте.', 'img/food/2020121611817717images (2).jfif', '2020-12-15 04:40:00');
INSERT INTO public.dishes (id, name, cooktime, portions, cookingmethod, img, creatingdate) VALUES (10, 'Вкусное блюдо', '04:05:00', 2, 'Очень надеюсь, что мой рецепт поможет новичкам замесить хорошее тесто и раскатать лепешки.  Начинку положила такую, какая была указана в рецепте.', 'img/food/202012161196550images (3).jfif', '2020-12-15 05:40:00');
INSERT INTO public.dishes (id, name, cooktime, portions, cookingmethod, img, creatingdate) VALUES (11, 'Название тестовое', '11:00:00', 1, 'Описание тестовое', 'img/food/2020121612525837images (1).jfif', '2020-12-15 06:40:00');
INSERT INTO public.dishes (id, name, cooktime, portions, cookingmethod, img, creatingdate) VALUES (12, 'Блюдо', '11:22:00', 1, 'Описание блюда', 'img/food/202012161265935images (2).jfif', '2020-12-15 07:40:00');
INSERT INTO public.dishes (id, name, cooktime, portions, cookingmethod, img, creatingdate) VALUES (13, 'Пицца с грибами', '11:22:00', 1, 'Описание блюда', 'img/food/2020121612631283images (5).jfif', '2020-12-15 08:40:00');
INSERT INTO public.dishes (id, name, cooktime, portions, cookingmethod, img, creatingdate) VALUES (14, 'Пицца с грибами', '11:22:00', 1, 'Описание блюда', 'img/food/2020121612640473images (2).jfif', '2020-12-15 09:40:00');
INSERT INTO public.dishes (id, name, cooktime, portions, cookingmethod, img, creatingdate) VALUES (15, 'Каша', '11:22:00', 1, 'Вкусная каша', 'img/default.png', '2020-12-15 10:40:00');
INSERT INTO public.dishes (id, name, cooktime, portions, cookingmethod, img, creatingdate) VALUES (16, 'dsfsfda', '04:00:00', 1, 'Это блюдо для меня новое, никогда раньше не готовила. Мне казалось, что оно сложное в приготовлении, так как опыта в раскатывании лепешек у меня нет. Вот решила попробовать, и со второй лепешки все получилось. Очень надеюсь, что мое видео поможет новичкам замесить хорошее тесто и раскатать лепешки.  Начинку положила такую, какая была указана в рецепте.', 'img/food/2020121614247184images (3).jfif', '2020-12-15 11:40:00');
INSERT INTO public.dishes (id, name, cooktime, portions, cookingmethod, img, creatingdate) VALUES (17, 'Пирог', '11:00:00', 13, 'Это блюдо для меня новое, никогда раньше не готовила. Мне казалось, что оно сложное в приготовлении, так как опыта в раскатывании лепешек у меня нет. Вот решила попробовать, и со второй лепешки все получилось. Очень надеюсь, что мое видео поможет новичкам замесить хорошее тесто и раскатать лепешки.  Начинку положила такую, какая была указана в рецепте.', 'img/food/2020121615246924images (3).jfif', '2020-12-16 00:00:00');
INSERT INTO public.dishes (id, name, cooktime, portions, cookingmethod, img, creatingdate) VALUES (18, 'Самое вкусное блюдо', '02:00:00', 1, 'Это блюдо для меня новое, никогда раньше не готовила. Мне казалось, что оно сложное в приготовлении, так как опыта в раскатывании лепешек у меня нет. Вот решила попробовать, и со второй лепешки все получилось. Очень надеюсь, что мое видео поможет новичкам замесить хорошее тесто и раскатать лепешки.  Начинку положила такую, какая была указана в рецепте.', 'img/food/202012161571242images (3).jfif', '2020-12-16 00:00:00');
INSERT INTO public.dishes (id, name, cooktime, portions, cookingmethod, img, creatingdate) VALUES (19, 'Кыстыбый', '11:00:00', 0, 'Это блюдо для меня новое, никогда раньше не готовила. Мне казалось, что оно сложное в приготовлении, так как опыта в раскатывании лепешек у меня нет. Вот решила попробовать, и со второй лепешки все получилось. Очень надеюсь, что мое видео поможет новичкам замесить хорошее тесто и раскатать лепешки.  Начинку положила такую, какая была указана в рецепте.', 'img/food/202012162330479images (3).jfif', '2020-12-16 00:00:00');
INSERT INTO public.dishes (id, name, cooktime, portions, cookingmethod, img, creatingdate) VALUES (20, 'Ролл', '11:00:00', 1, 'Вкусные роллы', 'img/food/202012161314143081.jfif', '2020-12-16 00:00:00');
INSERT INTO public.dishes (id, name, cooktime, portions, cookingmethod, img, creatingdate) VALUES (21, 'Кыстыбый', '04:09:00', 5, 'Описание блюда', 'img/food/202012161327156221.jfif', '2020-12-16 00:00:00');
INSERT INTO public.dishes (id, name, cooktime, portions, cookingmethod, img, creatingdate) VALUES (22, 'Еда', '01:00:00', 1, 'Описание блюда', 'img/food/202012161345327781.jfif', '2020-12-16 00:00:00');
INSERT INTO public.dishes (id, name, cooktime, portions, cookingmethod, img, creatingdate) VALUES (23, 'Кыстыбый', '23:12:00', 0, 'Это блюдо для меня новое, никогда раньше не готовила. Мне казалось, что оно сложное в приготовлении, так как опыта в раскатывании лепешек у меня нет. Вот решила попробовать, и со второй лепешки все получилось. Очень надеюсь, что мое видео поможет новичкам замесить хорошее тесто и раскатать лепешки.  Начинку положила такую, какая была указана в рецепте.', 'img/food/20201216143316491.jfif', '2020-12-16 00:00:00');


--
-- TOC entry 2910 (class 0 OID 33270)
-- Dependencies: 216
-- Data for Name: forum; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.forum (id, client_id, message, send_date_time) VALUES (0, 0, 'Привет всем!', '2020-12-16 01:27:26');
INSERT INTO public.forum (id, client_id, message, send_date_time) VALUES (1, 0, 'Как ваши дела?', '2020-12-16 01:27:34');
INSERT INTO public.forum (id, client_id, message, send_date_time) VALUES (2, 1, 'Привет!', '2020-12-16 01:54:22');
INSERT INTO public.forum (id, client_id, message, send_date_time) VALUES (3, 1, 'У меня все хорошо. Хочу есть :(', '2020-12-16 01:54:35');
INSERT INTO public.forum (id, client_id, message, send_date_time) VALUES (4, 2, 'а я не хочу есть!', '2020-12-16 02:03:48');
INSERT INTO public.forum (id, client_id, message, send_date_time) VALUES (5, 3, 'прикольный сайт))', '2020-12-16 14:03:57');
INSERT INTO public.forum (id, client_id, message, send_date_time) VALUES (6, 3, 'dksajfklasj', '2020-12-16 14:30:30');


--
-- TOC entry 2901 (class 0 OID 25051)
-- Dependencies: 207
-- Data for Name: personalinfo; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.personalinfo (id, mail, hashpassword) VALUES (0, 'galievarailina@gmail.com', '25d55ad283aa400af464c76d713c07ad');
INSERT INTO public.personalinfo (id, mail, hashpassword) VALUES (1, 'ivan@mail.ru', '25f9e794323b453885f5181f1b624d0b');
INSERT INTO public.personalinfo (id, mail, hashpassword) VALUES (2, 'test@mail.ri', '25d55ad283aa400af464c76d713c07ad');
INSERT INTO public.personalinfo (id, mail, hashpassword) VALUES (3, 'ivan@mail.com', '25f9e794323b453885f5181f1b624d0b');


--
-- TOC entry 2904 (class 0 OID 25077)
-- Dependencies: 210
-- Data for Name: products; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.products (id, name) VALUES (0, 'Мука - 280 г');
INSERT INTO public.products (id, name) VALUES (1, 'Молоко - 100мл');
INSERT INTO public.products (id, name) VALUES (2, 'Яйцо - 1шт.');
INSERT INTO public.products (id, name) VALUES (3, 'Молоко');
INSERT INTO public.products (id, name) VALUES (4, 'Мука');
INSERT INTO public.products (id, name) VALUES (5, 'Масло сливочное - 50 г');
INSERT INTO public.products (id, name) VALUES (6, 'Мука - 1 кг');
INSERT INTO public.products (id, name) VALUES (7, 'Яйца - 10 шт.');
INSERT INTO public.products (id, name) VALUES (8, 'Сахар - 35-40 г');
INSERT INTO public.products (id, name) VALUES (9, 'Мясо');
INSERT INTO public.products (id, name) VALUES (10, 'Картофель - 1 кг');
INSERT INTO public.products (id, name) VALUES (11, 'Чеснок - 1 зубчик');
INSERT INTO public.products (id, name) VALUES (12, 'Лук 1 кг');
INSERT INTO public.products (id, name) VALUES (13, 'Тестовый 1 ');
INSERT INTO public.products (id, name) VALUES (14, 'asdfafs');
INSERT INTO public.products (id, name) VALUES (15, 'asdf');
INSERT INTO public.products (id, name) VALUES (16, 'Рыба');
INSERT INTO public.products (id, name) VALUES (17, 'Морская капуста');
INSERT INTO public.products (id, name) VALUES (18, 'Лавровый лист - 1 шт.');


--
-- TOC entry 2907 (class 0 OID 25107)
-- Dependencies: 213
-- Data for Name: reviews; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.reviews (dish_id, client_id, description, id, send_date_time) VALUES (0, 1, 'Блюдо очень вкусное!', 0, '2020-12-16 01:54:13');
INSERT INTO public.reviews (dish_id, client_id, description, id, send_date_time) VALUES (18, 0, 'faaf', 1, '2020-12-16 12:57:01');
INSERT INTO public.reviews (dish_id, client_id, description, id, send_date_time) VALUES (0, 3, 'Мне тоже понравился рецепт) Спасибо!', 2, '2020-12-16 14:03:10');
INSERT INTO public.reviews (dish_id, client_id, description, id, send_date_time) VALUES (1, 3, 'Татарская выпечка кыстыбый - аппетитные лепёшки из пресного теста с начинкой. Один из вариантов начинки - картофельное пюре. Кыстыбый очень вкусный как теплый, так и остывший. Готовьте с удовольствием! Ведь самая лучшая выпечка та, что проверена поколениями!', 3, '2020-12-16 14:30:43');
INSERT INTO public.reviews (dish_id, client_id, description, id, send_date_time) VALUES (23, 3, 'Татарская выпечка кыстыбый - аппетитные лепёшки из пресного теста с начинкой. Один из вариантов начинки - картофельное пюре. Кыстыбый очень вкусный как теплый, так и остывший. Готовьте с удовольствием! Ведь самая лучшая выпечка та, что проверена поколениями!', 4, '2020-12-16 14:33:29');


--
-- TOC entry 2906 (class 0 OID 25085)
-- Dependencies: 212
-- Data for Name: steps; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.steps (dishid, numberofstep, description, img) VALUES (0, 0, 'Готовим начинку. Картофель вымыть, очистить, нарезать крупными кусками, отварить в подсоленной воде до готовности. Слить воду и размять картофель в пюре. Добавить горячее молоко, 1 ст. л. сливочного масла. Посолить (при необходимости) и тщательно перемешать.', 'img/steps/20201216051553481.jpg');
INSERT INTO public.steps (dishid, numberofstep, description, img) VALUES (0, 1, 'Лук вымыть, очистить, нарезать мелкими кубиками. В сковороде разогреть 0,5 ст. л. сливочного масла и обжарить на медленном огне лук до прозрачности. Добавить в картофельное пюре и перемешать.', 'img/steps/20201216051553582.jpg');
INSERT INTO public.steps (dishid, numberofstep, description, img) VALUES (0, 2, 'Готовим тесто. В глубокой миске смешиваем теплое (это важно!) молоко, сахарный песок, соль, яйцо и растопленное сливочное масло.', 'img/steps/20201216051553583.jpg');
INSERT INTO public.steps (dishid, numberofstep, description, img) VALUES (0, 3, 'В отдельную миску просеиваем муку. Начинаем постепенно добавлять в яично-молочную смесь и замешиваем тесто до тех пор, пока оно не перестанет прилипать к рукам (у меня ушло примерно 250 г муки). Накрыть полотенцем и дать отдохнуть в течение 20–30 минут.', 'img/steps/20201216051553594.jpg');
INSERT INTO public.steps (dishid, numberofstep, description, img) VALUES (1, 0, 'Начинка. Треугольная форма пирожков — не самая главная их особенность. Изюминкой эчпочмаков является мясная начинка, которая кладется в пирожки в сыром виде, — этим и отличается блюдо от другой мясной выпечки. Именно благодаря отверстию в тесте пирожки хорошо пропекаются и остаются сочными, ведь в него в процессе приготовления заливается бульон. Согласитесь, что татарские кулинары очень практичны и изобретательны', 'img/steps/20201216056552671.jpg');
INSERT INTO public.steps (dishid, numberofstep, description, img) VALUES (1, 1, 'Формирование пирожков. Из теста раскатывается жгут, нарезается кусочками, из которых формируются шарики. Каждый шарик раскатывается в виде круга размером с чайное блюдце, в его середину кладется 1 ст. л. начинки, и края круга в трех местах соединяются вверху, как пирамида. Защипывать швы следует «веревочкой» как можно тщательнее, иначе в процессе выпечки пирожки начнут разваливаться. При этом следует оставить небольшое отверстие для бульона. Если фарш делается из говядины или телятины, при формировании пирожка сверху на начинку кладется кусочек сливочного масла или сала, чтобы эчпочмак был сочнее.', 'img/steps/20201216056552692.jpg');
INSERT INTO public.steps (dishid, numberofstep, description, img) VALUES (1, 2, 'Готово!', 'img/default.png');
INSERT INTO public.steps (dishid, numberofstep, description, img) VALUES (2, 0, 'Яйца взбиваем в пену. Добавляем муку, соль и соду. Тесто должно получиться «крутым», на эластичным – как для пельменей. Правило тоже: тесто вымешиваем, пока оно не станет однородным. Муку добавляем до тех пор, пока тесто не перестанет липнуть к рукам.', 'img/default.png');
INSERT INTO public.steps (dishid, numberofstep, description, img) VALUES (2, 1, 'Готовое тесто убираем в мешок и оставляем в покое на 15 мин. Теперь отрезаем от теста небольшой кусок и скатываем колбаску ? 1 см. Делим её на дольки около 2.5 см.', 'img/steps/2020121611483013.jpg');
INSERT INTO public.steps (dishid, numberofstep, description, img) VALUES (2, 2, 'В толстостенный казан наливаем 1.5 л. подсолнечного масла, немного подогреваем. Теперь в теплое масло добавляем 1/2 ст. холодной воды, доводим до кипения.', 'img/steps/2020121611483034.jpg');
INSERT INTO public.steps (dishid, numberofstep, description, img) VALUES (2, 3, 'В масло кидаем дольки теста, накрываем крышкой, чуток прибавляем газ. Баурсак начнёт быстро раздуваться и как только увеличится вдвое, газ нужно убавить на минимум или вовсе сдвинуть казан с огня. Теперь выпечку нужно хорошо мешать. Баурсак ещё немного увеличивается в размерах и будет готов примерно через 2 мин. Выпечка должна всплыть, цвет должен быть ярко карамельным.', 'img/default.png');
INSERT INTO public.steps (dishid, numberofstep, description, img) VALUES (3, 0, 'Сварите мясной бульон. Выловите мясо из бульона, порежьте кусочками весом 30 г и обжарьте. Помойте и очистите лук, поджарьте и добавьте его к поджаренному мясу. Добавьте нарезанную кубиками морковь, томат-пюре, все хорошо перемешайте и жарьте еще в течение 5 минут.', 'img/default.png');
INSERT INTO public.steps (dishid, numberofstep, description, img) VALUES (20, 0, 'Шаг 1', 'img/steps/202012161316307171.jfif');
INSERT INTO public.steps (dishid, numberofstep, description, img) VALUES (20, 1, 'Шаг 2', 'img/default.png');
INSERT INTO public.steps (dishid, numberofstep, description, img) VALUES (21, 1, 'Шаг 2', 'img/steps/202012161328225961.jfif');
INSERT INTO public.steps (dishid, numberofstep, description, img) VALUES (23, 0, 'aSDad', 'img/steps/20201216143316651.jfif');
INSERT INTO public.steps (dishid, numberofstep, description, img) VALUES (23, 1, 'ASDAD', 'img/steps/2020121614331674unnamed.jpg');
INSERT INTO public.steps (dishid, numberofstep, description, img) VALUES (3, 1, 'Поджаренное мясо с овощами переложите в кастрюлю, залейте бульоном и доведите до кипения. Картофель очистите, порежьте дольками и добавьте в суп. Посолите, поперчите и поварите шурпу около 20 минут.', 'img/default.png');
INSERT INTO public.steps (dishid, numberofstep, description, img) VALUES (3, 2, 'Перед подачей на стол суп посыпьте зеленью укропа и петрушки.', 'img/default.png');
INSERT INTO public.steps (dishid, numberofstep, description, img) VALUES (4, 0, 'Готовим тесто', 'img/steps/202012161712955sm_254437.jpg');
INSERT INTO public.steps (dishid, numberofstep, description, img) VALUES (4, 1, 'Готовим начинку', 'img/steps/202012161712957sm_254379.jpg');
INSERT INTO public.steps (dishid, numberofstep, description, img) VALUES (5, 0, 'Шаг', 'img/default.png');
INSERT INTO public.steps (dishid, numberofstep, description, img) VALUES (6, 0, 'Очистить картофель, порезать кубиком, сложить в кастрюлю, залить водой. Добавить соль, лавровый лист и зубчик чеснока. Варить картофель до готовности, 25-30 минут. Лук порезать мелким кубиком, обжарить на сливочном масле до золотистого цвета, выложить в мисочку.', 'img/steps/2020121611313837Без названия (1).jfif');
INSERT INTO public.steps (dishid, numberofstep, description, img) VALUES (6, 1, 'Шаг2', 'img/steps/2020121611313846content_658e095df63555e26dc8ca86ffd0b9e0.jpg');
INSERT INTO public.steps (dishid, numberofstep, description, img) VALUES (7, 0, 'Описание первого шага', 'img/steps/2020121611453371iStock-694189032.jpg');
INSERT INTO public.steps (dishid, numberofstep, description, img) VALUES (8, 0, 'Очистить картофель, порезать кубиком, сложить в кастрюлю, залить водой. Добавить соль, лавровый лист и зубчик чеснока. Варить картофель до готовности, 25-30 минут. Лук порезать мелким кубиком, обжарить на сливочном масле до золотистого цвета, выложить в мисочку.', 'img/steps/2020121611629530iStock-694189032.jpg');
INSERT INTO public.steps (dishid, numberofstep, description, img) VALUES (8, 1, 'Шаг 2', 'img/steps/2020121611629531Без названия (2).jfif');
INSERT INTO public.steps (dishid, numberofstep, description, img) VALUES (9, 0, 'Очистить картофель, порезать кубиком, сложить в кастрюлю, залить водой. Добавить соль, лавровый лист и зубчик чеснока. Варить картофель до готовности, 25-30 минут. Лук порезать мелким кубиком, обжарить на сливочном масле до золотистого цвета, выложить в мисочку.', 'img/steps/2020121611817782images (4).jfif');
INSERT INTO public.steps (dishid, numberofstep, description, img) VALUES (10, 0, 'Лук порезать', 'img/steps/202012161196560images (3).jfif');
INSERT INTO public.steps (dishid, numberofstep, description, img) VALUES (11, 0, 'Очистить картофель, порезать кубиком, сложить в кастрюлю, залить водой. Добавить соль, лавровый лист и зубчик чеснока. Варить картофель до готовности, 25-30 минут. Лук порезать мелким кубиком, обжарить на сливочном масле до золотистого цвета, выложить в мисочку.', 'img/default.png');
INSERT INTO public.steps (dishid, numberofstep, description, img) VALUES (12, 0, 'Очистить картофель, порезать кубиком, сложить в кастрюлю, залить водой. Добавить соль, лавровый лист и зубчик чеснока. Варить картофель до готовности, 25-30 минут. Лук порезать мелким кубиком, обжарить на сливочном масле до золотистого цвета, выложить в мисочку.', 'img/steps/202012161265941images (1).jfif');
INSERT INTO public.steps (dishid, numberofstep, description, img) VALUES (13, 0, 'Очистить картофель, порезать кубиком, сложить в кастрюлю, залить водой. Добавить соль, лавровый лист и зубчик чеснока. Варить картофель до готовности, 25-30 минут. Лук порезать мелким кубиком, обжарить на сливочном масле до золотистого цвета, выложить в мисочку.', 'img/steps/2020121612631288images.jfif');
INSERT INTO public.steps (dishid, numberofstep, description, img) VALUES (13, 1, 'Шаг 2', 'img/steps/2020121612631289images (4).jfif');
INSERT INTO public.steps (dishid, numberofstep, description, img) VALUES (14, 0, 'Очистить картофель, порезать кубиком, сложить в кастрюлю, залить водой. Добавить соль, лавровый лист и зубчик чеснока. Варить картофель до готовности, 25-30 минут. Лук порезать мелким кубиком, обжарить на сливочном масле до золотистого цвета, выложить в мисочку.', 'img/default.png');
INSERT INTO public.steps (dishid, numberofstep, description, img) VALUES (15, 0, 'Очистить картофель, порезать кубиком, сложить в кастрюлю, залить водой. Добавить соль, лавровый лист и зубчик чеснока. Варить картофель до готовности, 25-30 минут. Лук порезать мелким кубиком, обжарить на сливочном масле до золотистого цвета, выложить в мисочку.', 'img/default.png');
INSERT INTO public.steps (dishid, numberofstep, description, img) VALUES (16, 0, 'Очистить картофель, порезать кубиком, сложить в кастрюлю, залить водой. Добавить соль, лавровый лист и зубчик чеснока. Варить картофель до готовности, 25-30 минут. Лук порезать мелким кубиком, обжарить на сливочном масле до золотистого цвета, выложить в мисочку.', 'img/steps/2020121614247217images (1).jfif');
INSERT INTO public.steps (dishid, numberofstep, description, img) VALUES (17, 0, 'Очистить картофель, порезать кубиком, сложить в кастрюлю, залить водой. Добавить соль, лавровый лист и зубчик чеснока. Варить картофель до готовности, 25-30 минут. Лук порезать мелким кубиком, обжарить на сливочном масле до золотистого цвета, выложить в мисочку.', 'img/steps/2020121615246952images (4).jfif');
INSERT INTO public.steps (dishid, numberofstep, description, img) VALUES (18, 0, 'шаг', 'img/steps/202012161571247images (4).jfif');
INSERT INTO public.steps (dishid, numberofstep, description, img) VALUES (19, 0, 'Очистить картофель, порезать кубиком, сложить в кастрюлю, залить водой. Добавить соль, лавровый лист и зубчик чеснока. Варить картофель до готовности, 25-30 минут. Лук порезать мелким кубиком, обжарить на сливочном масле до золотистого цвета, выложить в мисочку.', 'img/steps/202012162330490images (3).jfif');
INSERT INTO public.steps (dishid, numberofstep, description, img) VALUES (21, 0, 'Очистить картофель, порезать кубиком, сложить в кастрюлю, залить водой. Добавить соль, лавровый лист и зубчик чеснока. Варить картофель до готовности, 25-30 минут. Лук порезать мелким кубиком, обжарить на сливочном масле до золотистого цвета, выложить в мисочку.', 'img/steps/202012161328123221.jfif');
INSERT INTO public.steps (dishid, numberofstep, description, img) VALUES (22, 0, 'Очистить картофель, порезать кубиком, сложить в кастрюлю, залить водой. Добавить соль, лавровый лист и зубчик чеснока. Варить картофель до готовности, 25-30 минут. Лук порезать мелким кубиком, обжарить на сливочном масле до золотистого цвета, выложить в мисочку.', 'img/steps/202012161345328031.jfif');
INSERT INTO public.steps (dishid, numberofstep, description, img) VALUES (22, 1, 'Шаг 2', 'img/steps/202012161345328051.jfif');


--
-- TOC entry 2916 (class 0 OID 0)
-- Dependencies: 205
-- Name: order_of; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.order_of', 1, false);


--
-- TOC entry 2767 (class 2606 OID 33263)
-- Name: bookmarks bookmarks_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.bookmarks
    ADD CONSTRAINT bookmarks_pk PRIMARY KEY (dish_id, client_id);


--
-- TOC entry 2749 (class 2606 OID 16543)
-- Name: databasechangeloglock databasechangeloglock_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.databasechangeloglock
    ADD CONSTRAINT databasechangeloglock_pkey PRIMARY KEY (id);


--
-- TOC entry 2751 (class 2606 OID 16555)
-- Name: department department_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.department
    ADD CONSTRAINT department_pkey PRIMARY KEY (id);


--
-- TOC entry 2757 (class 2606 OID 25076)
-- Name: dish_client dish_client_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.dish_client
    ADD CONSTRAINT dish_client_pkey PRIMARY KEY (dish_id);


--
-- TOC entry 2765 (class 2606 OID 33255)
-- Name: dish_kitchen dish_kitchen_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.dish_kitchen
    ADD CONSTRAINT dish_kitchen_pk PRIMARY KEY (dish_id, kitchen_id);


--
-- TOC entry 2755 (class 2606 OID 25071)
-- Name: dishes dishes_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.dishes
    ADD CONSTRAINT dishes_pkey PRIMARY KEY (id);


--
-- TOC entry 2769 (class 2606 OID 33277)
-- Name: forum forum_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.forum
    ADD CONSTRAINT forum_pk PRIMARY KEY (id);


--
-- TOC entry 2753 (class 2606 OID 25058)
-- Name: personalinfo personalinfo_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.personalinfo
    ADD CONSTRAINT personalinfo_pkey PRIMARY KEY (id);


--
-- TOC entry 2761 (class 2606 OID 25092)
-- Name: steps pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.steps
    ADD CONSTRAINT pk PRIMARY KEY (dishid, numberofstep);


--
-- TOC entry 2759 (class 2606 OID 25081)
-- Name: products products_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.products
    ADD CONSTRAINT products_pkey PRIMARY KEY (id);


--
-- TOC entry 2763 (class 2606 OID 33269)
-- Name: reviews reviews_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.reviews
    ADD CONSTRAINT reviews_pk PRIMARY KEY (id);


-- Completed on 2020-12-19 20:21:56

--
-- PostgreSQL database dump complete
--

