PGDMP     "                     x            Test    12.4    12.4 -    a           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            b           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            c           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            d           1262    16538    Test    DATABASE     �   CREATE DATABASE "Test" WITH TEMPLATE = template0 ENCODING = 'UTF8' LC_COLLATE = 'Russian_Russia.1251' LC_CTYPE = 'Russian_Russia.1251';
    DROP DATABASE "Test";
                postgres    false            �            1259    33259 	   bookmarks    TABLE     `   CREATE TABLE public.bookmarks (
    dish_id integer NOT NULL,
    client_id integer NOT NULL
);
    DROP TABLE public.bookmarks;
       public         heap    postgres    false            �            1259    25042    order_of    SEQUENCE     q   CREATE SEQUENCE public.order_of
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
    DROP SEQUENCE public.order_of;
       public          postgres    false            �            1259    25044    clients    TABLE     �   CREATE TABLE public.clients (
    id integer DEFAULT nextval('public.order_of'::regclass),
    name character varying(100),
    surname character varying(100),
    login character varying(100),
    img character varying(100)
);
    DROP TABLE public.clients;
       public         heap    postgres    false    205            �            1259    16544    databasechangelog    TABLE     Y  CREATE TABLE public.databasechangelog (
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
 %   DROP TABLE public.databasechangelog;
       public         heap    postgres    false            �            1259    16539    databasechangeloglock    TABLE     �   CREATE TABLE public.databasechangeloglock (
    id integer NOT NULL,
    locked boolean NOT NULL,
    lockgranted timestamp without time zone,
    lockedby character varying(255)
);
 )   DROP TABLE public.databasechangeloglock;
       public         heap    postgres    false            �            1259    16550 
   department    TABLE     �   CREATE TABLE public.department (
    id integer NOT NULL,
    name character varying(50) NOT NULL,
    actice integer DEFAULT 1,
    country character varying(2)
);
    DROP TABLE public.department;
       public         heap    postgres    false            �            1259    25072    dish_client    TABLE     Y   CREATE TABLE public.dish_client (
    dish_id integer NOT NULL,
    client_id integer
);
    DROP TABLE public.dish_client;
       public         heap    postgres    false            �            1259    33251    dish_kitchen    TABLE     d   CREATE TABLE public.dish_kitchen (
    dish_id integer NOT NULL,
    kitchen_id integer NOT NULL
);
     DROP TABLE public.dish_kitchen;
       public         heap    postgres    false            �            1259    25082    dish_product    TABLE     R   CREATE TABLE public.dish_product (
    dish_id integer,
    product_id integer
);
     DROP TABLE public.dish_product;
       public         heap    postgres    false            �            1259    25064    dishes    TABLE     �   CREATE TABLE public.dishes (
    id integer NOT NULL,
    name character varying(400),
    cooktime time without time zone,
    portions integer,
    cookingmethod text,
    img character varying(100),
    creatingdate timestamp without time zone
);
    DROP TABLE public.dishes;
       public         heap    postgres    false            �            1259    33270    forum    TABLE     �   CREATE TABLE public.forum (
    id integer NOT NULL,
    client_id integer,
    message text,
    send_date_time timestamp without time zone
);
    DROP TABLE public.forum;
       public         heap    postgres    false            �            1259    25051    personalinfo    TABLE     �   CREATE TABLE public.personalinfo (
    id integer NOT NULL,
    mail character varying(200),
    hashpassword character varying(500)
);
     DROP TABLE public.personalinfo;
       public         heap    postgres    false            �            1259    25077    products    TABLE     [   CREATE TABLE public.products (
    id integer NOT NULL,
    name character varying(150)
);
    DROP TABLE public.products;
       public         heap    postgres    false            �            1259    25107    reviews    TABLE     �   CREATE TABLE public.reviews (
    dish_id integer NOT NULL,
    client_id integer NOT NULL,
    description text NOT NULL,
    id integer NOT NULL,
    send_date_time timestamp without time zone
);
    DROP TABLE public.reviews;
       public         heap    postgres    false            �            1259    25085    steps    TABLE     �   CREATE TABLE public.steps (
    dishid integer NOT NULL,
    numberofstep integer NOT NULL,
    description text,
    img character varying(100)
);
    DROP TABLE public.steps;
       public         heap    postgres    false            ]          0    33259 	   bookmarks 
   TABLE DATA           7   COPY public.bookmarks (dish_id, client_id) FROM stdin;
    public          postgres    false    215   �1       T          0    25044    clients 
   TABLE DATA           @   COPY public.clients (id, name, surname, login, img) FROM stdin;
    public          postgres    false    206   �1       Q          0    16544    databasechangelog 
   TABLE DATA           �   COPY public.databasechangelog (id, author, filename, dateexecuted, orderexecuted, exectype, md5sum, description, comments, tag, liquibase, contexts, labels, deployment_id) FROM stdin;
    public          postgres    false    203   �2       P          0    16539    databasechangeloglock 
   TABLE DATA           R   COPY public.databasechangeloglock (id, locked, lockgranted, lockedby) FROM stdin;
    public          postgres    false    202   �3       R          0    16550 
   department 
   TABLE DATA           ?   COPY public.department (id, name, actice, country) FROM stdin;
    public          postgres    false    204   �3       W          0    25072    dish_client 
   TABLE DATA           9   COPY public.dish_client (dish_id, client_id) FROM stdin;
    public          postgres    false    209   4       \          0    33251    dish_kitchen 
   TABLE DATA           ;   COPY public.dish_kitchen (dish_id, kitchen_id) FROM stdin;
    public          postgres    false    214   X4       Y          0    25082    dish_product 
   TABLE DATA           ;   COPY public.dish_product (dish_id, product_id) FROM stdin;
    public          postgres    false    211   �4       V          0    25064    dishes 
   TABLE DATA           `   COPY public.dishes (id, name, cooktime, portions, cookingmethod, img, creatingdate) FROM stdin;
    public          postgres    false    208   T5       ^          0    33270    forum 
   TABLE DATA           G   COPY public.forum (id, client_id, message, send_date_time) FROM stdin;
    public          postgres    false    216   �<       U          0    25051    personalinfo 
   TABLE DATA           >   COPY public.personalinfo (id, mail, hashpassword) FROM stdin;
    public          postgres    false    207   �=       X          0    25077    products 
   TABLE DATA           ,   COPY public.products (id, name) FROM stdin;
    public          postgres    false    210   '>       [          0    25107    reviews 
   TABLE DATA           V   COPY public.reviews (dish_id, client_id, description, id, send_date_time) FROM stdin;
    public          postgres    false    213   <?       Z          0    25085    steps 
   TABLE DATA           G   COPY public.steps (dishid, numberofstep, description, img) FROM stdin;
    public          postgres    false    212   �@       e           0    0    order_of    SEQUENCE SET     7   SELECT pg_catalog.setval('public.order_of', 1, false);
          public          postgres    false    205            �
           2606    33263    bookmarks bookmarks_pk 
   CONSTRAINT     d   ALTER TABLE ONLY public.bookmarks
    ADD CONSTRAINT bookmarks_pk PRIMARY KEY (dish_id, client_id);
 @   ALTER TABLE ONLY public.bookmarks DROP CONSTRAINT bookmarks_pk;
       public            postgres    false    215    215            �
           2606    16543 0   databasechangeloglock databasechangeloglock_pkey 
   CONSTRAINT     n   ALTER TABLE ONLY public.databasechangeloglock
    ADD CONSTRAINT databasechangeloglock_pkey PRIMARY KEY (id);
 Z   ALTER TABLE ONLY public.databasechangeloglock DROP CONSTRAINT databasechangeloglock_pkey;
       public            postgres    false    202            �
           2606    16555    department department_pkey 
   CONSTRAINT     X   ALTER TABLE ONLY public.department
    ADD CONSTRAINT department_pkey PRIMARY KEY (id);
 D   ALTER TABLE ONLY public.department DROP CONSTRAINT department_pkey;
       public            postgres    false    204            �
           2606    25076    dish_client dish_client_pkey 
   CONSTRAINT     _   ALTER TABLE ONLY public.dish_client
    ADD CONSTRAINT dish_client_pkey PRIMARY KEY (dish_id);
 F   ALTER TABLE ONLY public.dish_client DROP CONSTRAINT dish_client_pkey;
       public            postgres    false    209            �
           2606    33255    dish_kitchen dish_kitchen_pk 
   CONSTRAINT     k   ALTER TABLE ONLY public.dish_kitchen
    ADD CONSTRAINT dish_kitchen_pk PRIMARY KEY (dish_id, kitchen_id);
 F   ALTER TABLE ONLY public.dish_kitchen DROP CONSTRAINT dish_kitchen_pk;
       public            postgres    false    214    214            �
           2606    25071    dishes dishes_pkey 
   CONSTRAINT     P   ALTER TABLE ONLY public.dishes
    ADD CONSTRAINT dishes_pkey PRIMARY KEY (id);
 <   ALTER TABLE ONLY public.dishes DROP CONSTRAINT dishes_pkey;
       public            postgres    false    208            �
           2606    33277    forum forum_pk 
   CONSTRAINT     L   ALTER TABLE ONLY public.forum
    ADD CONSTRAINT forum_pk PRIMARY KEY (id);
 8   ALTER TABLE ONLY public.forum DROP CONSTRAINT forum_pk;
       public            postgres    false    216            �
           2606    25058    personalinfo personalinfo_pkey 
   CONSTRAINT     \   ALTER TABLE ONLY public.personalinfo
    ADD CONSTRAINT personalinfo_pkey PRIMARY KEY (id);
 H   ALTER TABLE ONLY public.personalinfo DROP CONSTRAINT personalinfo_pkey;
       public            postgres    false    207            �
           2606    25092    steps pk 
   CONSTRAINT     X   ALTER TABLE ONLY public.steps
    ADD CONSTRAINT pk PRIMARY KEY (dishid, numberofstep);
 2   ALTER TABLE ONLY public.steps DROP CONSTRAINT pk;
       public            postgres    false    212    212            �
           2606    25081    products products_pkey 
   CONSTRAINT     T   ALTER TABLE ONLY public.products
    ADD CONSTRAINT products_pkey PRIMARY KEY (id);
 @   ALTER TABLE ONLY public.products DROP CONSTRAINT products_pkey;
       public            postgres    false    210            �
           2606    33269    reviews reviews_pk 
   CONSTRAINT     P   ALTER TABLE ONLY public.reviews
    ADD CONSTRAINT reviews_pk PRIMARY KEY (id);
 <   ALTER TABLE ONLY public.reviews DROP CONSTRAINT reviews_pk;
       public            postgres    false    213            ]   H   x�%���0��0�v�]����HQlC3���F�LNa���e�m�	\Q~<	����kB�:�z ���      T   �   x�}�;
�@���Sx�d��Xz �H�1����؉��)�@�(����]�`!����7�3�.��i�`o��W�fK�q��\%i��|�
&�ɥ���y��(tFEL%�Q�44�ք������	���^��p�A�����	&���ؙ0e��C�1����DQAp6g�z�c��0R�<�9EӾC)}����      Q   �   x��лn�0��y�� ���;+dCUoHX��O���@��}acci�3�����3]f}�_��u�[d^ʷ8��1���tR\�eZ��,��2�����S��ӨРY��B�\���5�
+P�g��}4�kG�}]� �e�*Cj�d�mL�i0o�0�H��
��ck+���� #��UFl���$�J�(9>�����u�ￔ^ѽ(T�j��x��J�=;G)�ҽ.��M��      P      x�3�L��"�=... U�      R      x������ � �      W   D   x�ʱ�0���g��]���_u]�ll�m������$'�2/337�3?w<%�k &J��. ?: �      \   c   x�5�A� ��_0lĿ��wH�x�tKҡ�����^��,���9}^�2n?d��Sp�0���s7̙��4�ON�)�v.����x�W���������      Y   y   x�5���0��0�%ˎ�K���$�>x8��#�)dL��B�f�`�E;����!$�yѸ��>y�LzFN�^�D�ҴO��U�sY����#ɕe��P��6��t��$����� ?g*#.      V   C  x��ZKnG]�N1���鞿�@P,ѱ �{��"T�ĉ7�c;�8$%JC�w��+�$yU�M9#BA`@@[����U��իɞ������7���k�x���#��C���\ZP��@ej�?�w��@uԅ���<)<�Nޝ7�5/��U]��sV\�a~�;&آ��h_��E�u�#6I�5W}�;��{T��p����ХM.s���ɧ����jJ��|��p(om-��`���H^�p�����k���&�+,�ln�8%ǐ���d��� �<z��^�ٳ�{ғ��"�B������Z�rK��������������w�g�v1ert-rq�\��X�$���'D4��Gj�x	 OM��>R4Xn�"��q�� fd�  �Zm����h{�x��w�:������.���Ǚ���R?�,!���8�� �0R�&�϶h+'���'��SM���t��Ve#
C�y�����^��_pW��$��$#\z�����or�7L�
�����F�:��`�.<���K
���o���0A���em�-������u��!E� .63��O�R&��kp`����4�c̯Y��{�&�1=�q
�p���{R�m��Ō{�9���-s�r���N�����d�`����`C�P��
b�9��]0C;�R�hԭGG٣rT(��(�X�*a��D�Q���xgQ���[��.��9��y�-�$ݎ�{Te("C��鐸�Nr2Hh�2���'�X��zm����}��q���S*��ΞV���T��RWa�@
;Z���@�=�_�HJ��*HD�~=x������Q��yi�[��0�d�� y��D����m��-��I�T�p�K��l��ājOY���w]�.T��eU�5ጸ��jw~��m|��RS����r��A����H��	�u���_�%e0~s[�0�u��Y���.�3��l�o����!8�uEb6зr��)�����qO7�S�i/���=���xZ�I� 5��L�|����3��E]��{���߿�=Z���X�6����E3��g�h����Ei!OG��alq�F.��(�K��`z��l�8�;ߐ��\�i��"u���LG/�d���#;��7ÒyH��7�X�ኅ�j�BDkɵI������q�PQ�%�t�z�B��d[�����3e�8������KNhD��/(pmqLߌ9�	�ul�='g\=����&�J$�y��!��F�'4�h��gE�r��ir˸��@�/�v�Lm�_������F�	�� �ǩ��#g_�5��c�ұi�	�M�t�����a�gh*� @cO}c�CԀ1Q,`32`���k�Ba��c��#�'�G�.Su��7�?�ڄ�/@eq!������K�q(쀆G���u����(���2�ԏg	*(H��4���v�M�v�W��T��lM�5y�8y�"~�d��޾��������"{+��"so�`i������׳h�h�mQ��B���9B�������7�����
w"����lî�7�]� �0��Ul��A�އ0�P=��Hu��q�2�a���!�b>^��pH��t���Y�7�D&�ٲbvv���l�g�u{��z� I�B0��a��u���e���^3��1;�A�ʛ���G"q��A�L��|M�;L�X�@ފ�i�7�3E���^��α[�>F��6�`�G�h��7��W�l����@��,�
�hET�/����-�za�e,�H�U������{+�JW[	B�WF嗣��}!�ʰV���(T_DA�����666���1      ^   �   x�e��JCAF띧;S$���{#��"6�H���JP0�>���/�@~����9W�[l�3�;��OXc��֌�N���ʉ�������������Y_�f|�~�|{IĂą��޲H"��co����*X�hm�N�c|��E��<�u����K*�8dn=��1w� ��T�P���o�v:��7l�R26Zw:�\(Z��Se��h<>����&z{t�#�骒�      U   }   x���;�0Dk�a��ݵM�AҬ���J(��x�f�eje�U����]z��rf�l���R�Q�.{�I{�`T�e~��{�/�'��1�l��&:KYG�j+���۳o�����W �9;      X     x�UPIN�@<�_1H4��$��K�(���I �N8.qY$6�/T���0�КQUO-�<�r�s��w8H �5�BC<x�O�2H���޶���/�˒vz����8�#
4z�/.��Ȣ��y��x9���)b޵^�;*�pćY/�
����E#�'x2^W��F�Z�t����e�Z��{�:����[Kӽ`�W{a�(�'R�d2��&���,^%���=��Q��XZ1ݘX�o]G!.�˖H��N�~�蘪m|��c"ڤ      [   �  x��RKn�0]'�p��
���O����*�@ �]UUjORܚ�fn�7��8AՅe{<�>3ց	hI5�iM���'di�3E%U<���!:�u�;&�+�M�K3����~ �_�&�zי6���^�a� ��8�xH8�G�P�Z~ ���E�H*@�hEM�G�i�������r�!�+�(�)�-� �`c
���Fu��>#'��C�jϾ�G�9�oH���&|�Aȶ\)��8�6]Eo�#��R��X�C��%N�T^<^�j�������1�/@��˄�Zb�r���j8%\:/�1/�gR%�x,�ȍ��veP����'�k���m��
&@<�}ᆂ�p��`+Ƥ�g���>�xPa��Ot�&a����ώ<=y�ŷ�]7�3�ژ      Z   E  x��Y�n��]�_���@[n��~d�?�6�@�$�I�1`Ͼ#K�	�8�`��Y�"-�[��A���KR�Խ|K�di5�n�޺�8u�n����J�K�t��I�D��I��4=����E:�v����o�y�L�:I�'��8�o[�����H�D�	De�G�w��0I��56&L�Q�H��Ic9�"�:�<Nf�*N�"k-��R��q2w��I�3��*!:�([� J�8r�H��N���h�`���@y��A��ɖ���aC�}(�E�U�EN�r\�ˮ����hY
�ϡ�J�Ë�,���v}W��1k-���2�j�=Z0N����.D�Ms:{%��÷��>{��嫽/xm��zn��A�w���o^<���r��?IL�G4W8^���X��"M����������x_�i��n���`?rQ��/�Ь�����ki�F,WT�#4�#2��B6����B��������{մCL�ML���K����W�����Oz|5���-�,������������^�"b*����j ������N���5Di�<Ⱥz^�<Z|�/|��3�ga���d$/#'?����Q�8˼�2��W��Ā	��R@#U���~R��VJ�?�uϫ[c�}�
[Jb`4V�I��Q:V#��*�M���Ē�N��������ݶ�D��mA�q�Іz�|�R���c�z����9VC@��'vHgFb���i���f�t��tj�&ՂL�wzb�d796�}ߒ9V�ܕy{����4��~�	�S�#��eǁc(�� ��t��NTq�]�1��!�sD
�j��#{ĺhHt�|f���'��ò%�:�������E��	�.��i.�LT;QZ���rn��(�S2���[��W)Ϩ�99twjk���T��,�̨�(U�Σ�b�t���-� ܳg3��� !X�p/� �?����珔���+E8)��陹JhI
�7�-",2f����TqLW�X��Z���.�"��ȝ���k�,��bk�Bw���X����,�����&K�4���_�%���兢9����4�?זq!�W2�\���ڔ��m�Ē��ynF�\�#��e?���X]�W7�fI`;�sc�622%9L�K[mL* "-JQ� ,4r�U��b�V�gZN%L2g�0���@��=�4G~hr� ��$��F4��1�NN��y�W��u�m��Z`��O�R��(4��4��̄��5�\i��Pdl�7�W�/j��[��64a�t�v��eC���V���A�qA�3-�hRa"m��������]��=r��(��HхB�&$�nS��y�2$S�z!+n�º,̦)-ݣ�A�ms���6��舾�Z�Gת�s�,3�E؛�3yg��)5��ܱ������^m�x�䎇��o��H��Y�c�-NJ5+h�]�LG���@��+/��'��x!	��$�է�R�xB�=�c9X�,7|�LFh!�'���#�*z�"������T� ���ʽ��:�Q-9���Jc�κ��,jt}?��d��{��к��Â����?6��>��ɜZ}����nQc�Z�~3/F���[�V���,{��jA��!t��F��K�=������j��3�:3��B���]���@�5��v�~��{���y��Y���dm�X���G�}�(��1�Bšǚ$\'��zd���.{��B�n������@��g�#GK�lC����ԛ�Fĝ�Ȯw��1n��_A���,����t�KM!�lP�� �!'�¶��;G<�K���	>r��p�E¤�7�Z�P�
�N;n5���L�P�f�˴3ͯ�9�A��z=)!�p#b�}�l����Z�����T�p&��NBX��hȫ<KV�D��/�5j���o4�`,�]��J��&�j>S�ʺ����Ry��r&y_�V��ʁ%�
��lK�V���Us�♹K�2r:��˾mۛH�G=�1�[2��7����.u�S\�֤�Ҵ�������s^��+��[qD��t�Ȧ�R�D�!_6%kY")l7�C����-J��'0��
������{*SD��llin�%��� ���(_A�#���%���W&Am�Q*�m���3;n��n�o�\\����c�k�{uin�mU����`е� ��Gwv�w|9��kݭ/=���k{�o�?�y��K*�zb��T�PХ��q��^�a2x2�S2����~ֲ��H�q6��u`5���OD7�O^J��M��Lf�\Ug�V�!�C�_�O���#��R#Q����ă�ͅ��oi`6�:}]�S��*��a�d��	/�Py�ͪ�욏xI�)ѩʻ�&�\o/�}����#�:�V��M�ZA=��d�VS��W-�h�PP�ey&F�M��0�on�ش�A>:�q�^��[��:I���B˚����/~�h�Fu�w�����#Y�~㩹���擤�+K톺ʻ6��;Z�Z���˲�*X���c�E�[F���~O�9[�l�s���=%�nƧ�tJ1��㯟��{��n��k��������}�������=�k�=b���Qq�T��G�N�����{��G��~����A��ھ޹��2w����5`��н�9��l@u�@�w{�����Γ���ݎ���V���F1�n�m[)���n���é�Y��&ܟy�+i�u)C6�m#���6����+2�ܒ�A��t6����S��&ܷ)ܛ��������<�W�z �. ^�;�7M̱tָ��
�j�6s�ۅ��۝Am��m����z�������m@'�� ?�\��/ۿھs�� 
�2�     