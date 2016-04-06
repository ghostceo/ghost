-module (proto_pack). 
-compile([export_all]).
-include("all_pb.hrl").
-include("mm_define.hrl").
-define( LIST(L),(if L =:= undefined -> []; true -> L end )).
-define( INT(I),(if is_integer(I) -> I; is_list(I) -> list_to_integer(I); is_float(I) -> round(I); true -> 0 end )).
-define( PACK_INT(N),(?INT(element(N,R))):32/integer-signed ).
-define( PACK_BOOL(N),(if(element(N,R)) -> 1; true -> 0 end):8/integer-signed ).
-define( PACK_STR(N),(pack_string( element(N,R) ))/binary ).
-define( PACK_FLOAT(N),(element(N,R)):64/big-float ).
-define( PACK_LIST(N,T),(length(?LIST(element(N,R)))):16,(pack_list(T, ?LIST(element(N,R))))/binary).
-define( PACK_TYPE(N,T),(pack(T, element(N,R)))/binary ).

%%common proto 
pack(_, undefined) -><<0:8/integer-signed>>;
pack(p_line_info, R) -><<
1:8/integer-signed,?PACK_STR(2),?PACK_STR(3),?PACK_INT(4),?PACK_STR(5)
>>;
pack(p_role_info, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_STR(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7)
>>;
pack(p_bag_content, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_LIST(3,p_goods),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7)
>>;
pack(p_skill_pos, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3)
>>;
pack(p_team_role, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_STR(3),?PACK_INT(4),?PACK_TYPE(5,p_skin),?PACK_INT(6),?PACK_STR(7),?PACK_INT(8),?PACK_INT(9),?PACK_INT(10),?PACK_INT(11),?PACK_INT(12),?PACK_INT(13),?PACK_INT(14),?PACK_BOOL(15),?PACK_BOOL(16),?PACK_BOOL(17),?PACK_INT(18),?PACK_INT(19),?PACK_INT(20),?PACK_INT(21),?PACK_INT(22),?PACK_INT(23),?PACK_INT(24),?PACK_INT(25)
>>;
pack(p_team_nearby, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_INT(8),?PACK_INT(9),?PACK_INT(10),?PACK_STR(11),?PACK_BOOL(12)
>>;
pack(p_friend_info, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_STR(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6),?PACK_BOOL(7),?PACK_STR(8),?PACK_STR(9),?PACK_INT(10),?PACK_INT(11),?PACK_INT(12)
>>;
pack(p_letter_info, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_STR(3),?PACK_STR(4),?PACK_STR(5),?PACK_INT(6),?PACK_INT(7),?PACK_LIST(8,p_goods),?PACK_LIST(9,p_goods),?PACK_INT(10),?PACK_STR(11),?PACK_INT(12)
>>;
pack(p_letter_goods, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3)
>>;
pack(p_letter_simple_info, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_STR(3),?PACK_STR(4),?PACK_STR(5),?PACK_INT(6),?PACK_INT(7),?PACK_INT(8),?PACK_BOOL(9),?PACK_INT(10)
>>;
pack(p_letter_send_condition, R) -><<
1:8/integer-signed,?PACK_LIST(2,string),?PACK_LIST(3,int32),?PACK_LIST(4,int32),?PACK_INT(5),?PACK_INT(6)
>>;
pack(p_letter_delete, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_BOOL(3),?PACK_INT(4)
>>;
pack(p_mount_info, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_INT(8),?PACK_INT(9)
>>;
pack(p_equip_endurance_info, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4)
>>;
pack(p_role_attr_change, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_FLOAT(3)
>>;
pack(p_other_role_info, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_STR(3),?PACK_INT(4),?PACK_INT(5),?PACK_STR(6),?PACK_INT(7),?PACK_INT(8),?PACK_INT(9),?PACK_LIST(10,p_goods),?PACK_INT(11),?PACK_INT(12),?PACK_STR(13),?PACK_TYPE(14,p_skin),?PACK_FLOAT(15),?PACK_TYPE(16,p_fst_attr),?PACK_TYPE(17,p_fst_attr),?PACK_TYPE(18,p_sec_attr)
>>;
pack(p_depot_bag, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_LIST(3,p_goods)
>>;
pack(p_shortcut, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_STR(4)
>>;
pack(p_family_bonus, R) -><<
1:8/integer-signed,?PACK_FLOAT(2),?PACK_INT(3),?PACK_STR(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_INT(8),?PACK_INT(9),?PACK_INT(10)
>>;
pack(p_sys_config, R) -><<
1:8/integer-signed,?PACK_BOOL(2),?PACK_BOOL(3),?PACK_BOOL(4),?PACK_BOOL(5),?PACK_BOOL(6),?PACK_BOOL(7),?PACK_BOOL(8),?PACK_BOOL(9)
>>;
pack(p_activity_completion_new, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6)
>>;
pack(p_activity_reward_list, R) -><<
1:8/integer-signed,?PACK_LIST(2,int32)
>>;
pack(p_time_gift_info, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_LIST(3,p_goods),?PACK_INT(4)
>>;
pack(p_pet_collect, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6)
>>;
pack(p_pet_eat_item, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3)
>>;
pack(p_bigpve_rank, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_STR(4),?PACK_INT(5),?PACK_FLOAT(6)
>>;
pack(p_role_goal, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_LIST(3,p_goal_condition),?PACK_INT(4)
>>;
pack(p_goal_condition, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5)
>>;
pack(p_compare_info, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6),?PACK_BOOL(7)
>>;
pack(p_team_mirror_info, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_STR(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6),?PACK_FLOAT(7),?PACK_BOOL(8)
>>;
pack(p_super_prop, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3)
>>;
pack(p_super_task, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_INT(8),?PACK_LIST(9,p_super_prop)
>>;
pack(p_stone_eat, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3)
>>;
pack(p_shop_info, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_STR(3),?PACK_LIST(4,p_shop_info)
>>;
pack(p_chat_role, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_STR(3),?PACK_INT(4),?PACK_STR(5),?PACK_INT(6),?PACK_INT(7),?PACK_STR(8),?PACK_LIST(9,p_chat_title)
>>;
pack(p_chat_title, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_STR(3),?PACK_STR(4)
>>;
pack(p_title, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_STR(3),?PACK_INT(4),?PACK_BOOL(5),?PACK_INT(6),?PACK_INT(7),?PACK_BOOL(8),?PACK_BOOL(9),?PACK_STR(10)
>>;
pack(p_chat_channel_role_info, R) -><<
1:8/integer-signed,?PACK_STR(2),?PACK_INT(3),?PACK_INT(4),?PACK_STR(5),?PACK_INT(6),?PACK_INT(7),?PACK_STR(8),?PACK_INT(9),?PACK_STR(10),?PACK_BOOL(11)
>>;
pack(p_channel_info, R) -><<
1:8/integer-signed,?PACK_STR(2),?PACK_INT(3),?PACK_STR(4),?PACK_INT(5),?PACK_INT(6)
>>;
pack(p_actor_buf, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_INT(8),?PACK_INT(9),?PACK_INT(10),?PACK_INT(11)
>>;
pack(p_skin, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_INT(8),?PACK_INT(9),?PACK_LIST(10,int32),?PACK_INT(11)
>>;
pack(p_fst_attr, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5)
>>;
pack(p_sec_attr, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_INT(8),?PACK_INT(9),?PACK_INT(10),?PACK_INT(11),?PACK_INT(12),?PACK_INT(13),?PACK_INT(14),?PACK_INT(15),?PACK_INT(16),?PACK_INT(17),?PACK_INT(18),?PACK_INT(19),?PACK_INT(20),?PACK_INT(21),?PACK_INT(22),?PACK_INT(23),?PACK_INT(24),?PACK_INT(25),?PACK_INT(26),?PACK_INT(27),?PACK_INT(28),?PACK_INT(29),?PACK_INT(30),?PACK_INT(31),?PACK_INT(32),?PACK_INT(33),?PACK_INT(34),?PACK_INT(35),?PACK_INT(36),?PACK_INT(37),?PACK_INT(38),?PACK_INT(39),?PACK_INT(40),?PACK_INT(41),?PACK_INT(42),?PACK_INT(43),?PACK_INT(44),?PACK_INT(45),?PACK_INT(46),?PACK_INT(47),?PACK_INT(48),?PACK_INT(49),?PACK_INT(50),?PACK_INT(51),?PACK_INT(52),?PACK_INT(53),?PACK_INT(54),?PACK_INT(55),?PACK_INT(56),?PACK_INT(57),?PACK_INT(58),?PACK_INT(59),?PACK_INT(60),?PACK_INT(61),?PACK_INT(62),?PACK_INT(63),?PACK_INT(64),?PACK_INT(65),?PACK_INT(66),?PACK_INT(67),?PACK_INT(68),?PACK_INT(69),?PACK_INT(70)
>>;
pack(p_role_base, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_STR(3),?PACK_STR(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_INT(8),?PACK_INT(9),?PACK_INT(10),?PACK_INT(11),?PACK_STR(12),?PACK_STR(13),?PACK_STR(14),?PACK_INT(15),?PACK_INT(16),?PACK_INT(17),?PACK_LIST(18,p_actor_buf),?PACK_INT(19),?PACK_INT(20),?PACK_BOOL(21),?PACK_INT(22),?PACK_INT(23),?PACK_INT(24),?PACK_TYPE(25,p_fst_attr),?PACK_TYPE(26,p_fst_attr),?PACK_TYPE(27,p_sec_attr),?PACK_FLOAT(28)
>>;
pack(p_role_pos, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_TYPE(4,p_pos),?PACK_STR(5),?PACK_STR(6)
>>;
pack(p_role_fight, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4)
>>;
pack(p_role_attr, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_STR(3),?PACK_FLOAT(4),?PACK_FLOAT(5),?PACK_INT(6),?PACK_LIST(7,p_goods),?PACK_TYPE(8,p_skin),?PACK_INT(9),?PACK_INT(10),?PACK_INT(11),?PACK_INT(12),?PACK_FLOAT(13),?PACK_FLOAT(14),?PACK_BOOL(15),?PACK_INT(16),?PACK_STR(17),?PACK_INT(18),?PACK_STR(19),?PACK_BOOL(20),?PACK_INT(21),?PACK_INT(22),?PACK_BOOL(23),?PACK_BOOL(24),?PACK_FLOAT(25),?PACK_FLOAT(26),?PACK_INT(27),?PACK_LIST(28,p_medal),?PACK_INT(29),?PACK_INT(30),?PACK_INT(31),?PACK_INT(32),?PACK_INT(33),?PACK_INT(34)
>>;
pack(p_medal, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3)
>>;
pack(p_role_ext, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_STR(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_INT(8),?PACK_STR(9),?PACK_INT(10),?PACK_INT(11),?PACK_INT(12),?PACK_STR(13),?PACK_INT(14),?PACK_LIST(15,int32)
>>;
pack(p_role, R) -><<
1:8/integer-signed,?PACK_TYPE(2,p_role_base),?PACK_TYPE(3,p_role_fight),?PACK_TYPE(4,p_role_pos),?PACK_TYPE(5,p_role_attr),?PACK_TYPE(6,p_role_ext)
>>;
pack(p_skill, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_STR(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6),?PACK_LIST(7,int32)
>>;
pack(p_skill_precondition, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3)
>>;
pack(p_role_skill, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3)
>>;
pack(p_skill_level, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_LIST(5,int32),?PACK_INT(6),?PACK_INT(7),?PACK_INT(8),?PACK_INT(9),?PACK_LIST(10,int32),?PACK_LIST(11,int32)
>>;
pack(p_skill_item_consume, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3)
>>;
pack(p_effect, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7)
>>;
pack(p_buf, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_INT(8),?PACK_INT(9),?PACK_BOOL(10),?PACK_INT(11),?PACK_INT(12)
>>;
pack(p_map_doll, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_STR(3),?PACK_STR(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_INT(8),?PACK_TYPE(9,p_pos)
>>;
pack(p_pos, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6)
>>;
pack(p_map_tile, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3)
>>;
pack(p_walk_path, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_LIST(4,p_map_tile),?PACK_INT(5),?PACK_INT(6)
>>;
pack(p_map_role, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_STR(3),?PACK_INT(4),?PACK_STR(5),?PACK_INT(6),?PACK_STR(7),?PACK_TYPE(8,p_pos),?PACK_TYPE(9,p_walk_path),?PACK_TYPE(10,p_pos),?PACK_INT(11),?PACK_INT(12),?PACK_INT(13),?PACK_INT(14),?PACK_TYPE(15,p_skin),?PACK_INT(16),?PACK_INT(17),?PACK_INT(18),?PACK_INT(19),?PACK_INT(20),?PACK_BOOL(21),?PACK_LIST(22,p_actor_buf),?PACK_STR(23),?PACK_INT(24),?PACK_BOOL(25),?PACK_INT(26),?PACK_INT(27),?PACK_INT(28),?PACK_INT(29),?PACK_INT(30),?PACK_INT(31),?PACK_FLOAT(32),?PACK_BOOL(33),?PACK_INT(34)
>>;
pack(p_map_dropthing, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_BOOL(3),?PACK_BOOL(4),?PACK_INT(5),?PACK_LIST(6,int32),?PACK_TYPE(7,p_pos),?PACK_INT(8),?PACK_INT(9),?PACK_INT(10),?PACK_INT(11),?PACK_INT(12),?PACK_TYPE(13,p_drop_property)
>>;
pack(p_use_requirement, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7)
>>;
pack(p_property_add, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_INT(8),?PACK_INT(9),?PACK_INT(10),?PACK_INT(11),?PACK_INT(12),?PACK_INT(13),?PACK_INT(14),?PACK_INT(15),?PACK_INT(16),?PACK_INT(17),?PACK_INT(18),?PACK_INT(19),?PACK_INT(20),?PACK_INT(21),?PACK_INT(22),?PACK_INT(23),?PACK_INT(24),?PACK_INT(25),?PACK_INT(26),?PACK_INT(27),?PACK_INT(28),?PACK_INT(29),?PACK_INT(30),?PACK_INT(31),?PACK_INT(32),?PACK_INT(33),?PACK_INT(34),?PACK_INT(35),?PACK_INT(36),?PACK_INT(37),?PACK_INT(38),?PACK_INT(39),?PACK_INT(40),?PACK_INT(41),?PACK_INT(42),?PACK_INT(43),?PACK_INT(44),?PACK_INT(45),?PACK_INT(46),?PACK_INT(47),?PACK_INT(48),?PACK_INT(49),?PACK_INT(50),?PACK_INT(51),?PACK_INT(52),?PACK_INT(53)
>>;
pack(p_equip_base_info, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_STR(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_TYPE(8,p_use_requirement),?PACK_INT(9),?PACK_INT(10),?PACK_INT(11),?PACK_TYPE(12,p_attr),?PACK_INT(13)
>>;
pack(p_item_effect, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_STR(3)
>>;
pack(p_item_base_info, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_STR(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_INT(8),?PACK_INT(9),?PACK_TYPE(10,p_use_requirement),?PACK_LIST(11,p_item_effect),?PACK_INT(12),?PACK_INT(13),?PACK_INT(14),?PACK_INT(15)
>>;
pack(p_stone_base_info, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_STR(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_TYPE(8,p_attr),?PACK_INT(9),?PACK_INT(10),?PACK_INT(11),?PACK_INT(12),?PACK_INT(13)
>>;
pack(p_attr, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4)
>>;
pack(p_super_equip, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5)
>>;
pack(p_reinforce, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4)
>>;
pack(p_super_suit, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_BOOL(3),?PACK_LIST(4,p_attr)
>>;
pack(p_goods, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_STR(5),?PACK_INT(6),?PACK_INT(7),?PACK_INT(8),?PACK_INT(9),?PACK_BOOL(10),?PACK_INT(11),?PACK_INT(12),?PACK_INT(13),?PACK_STR(14),?PACK_INT(15),?PACK_INT(16),?PACK_TYPE(17,p_reinforce),?PACK_INT(18),?PACK_TYPE(19,p_attr),?PACK_LIST(20,p_attr),?PACK_LIST(21,p_attr),?PACK_LIST(22,p_attr),?PACK_TYPE(23,p_super_equip),?PACK_LIST(24,p_goods),?PACK_LIST(25,p_super_suit),?PACK_INT(26),?PACK_INT(27),?PACK_INT(28)
>>;
pack(p_equip_bind_attr, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6)
>>;
pack(p_equip_whole_attr, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_INT(8),?PACK_INT(9)
>>;
pack(p_refresh_info, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_INT(8),?PACK_INT(9),?PACK_INT(10),?PACK_INT(11),?PACK_INT(12),?PACK_INT(13),?PACK_INT(14),?PACK_INT(15),?PACK_INT(16),?PACK_INT(17),?PACK_INT(18)
>>;
pack(p_monster_skill, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3)
>>;
pack(p_drop_property, R) -><<
1:8/integer-signed,?PACK_BOOL(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6)
>>;
pack(p_drop_colour_mode, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3)
>>;
pack(p_drop_quality_mode, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3)
>>;
pack(p_drop_hole_mode, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3)
>>;
pack(p_drop_mode, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_LIST(4,p_drop_colour_mode),?PACK_LIST(5,p_drop_colour_mode),?PACK_LIST(6,p_drop_quality_mode),?PACK_LIST(7,p_drop_quality_mode),?PACK_LIST(8,p_drop_hole_mode),?PACK_LIST(9,p_drop_hole_mode),?PACK_INT(10)
>>;
pack(p_single_drop, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4)
>>;
pack(p_drop_info, R) -><<
1:8/integer-signed,?PACK_LIST(2,p_single_drop),?PACK_INT(3),?PACK_INT(4),?PACK_TYPE(5,p_drop_mode)
>>;
pack(p_monster_drop_info, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_LIST(3,p_drop_info)
>>;
pack(p_monster_base_info, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_STR(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6),?PACK_TYPE(7,p_sec_attr),?PACK_INT(8),?PACK_INT(9)
>>;
pack(p_enemy, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_TYPE(5,p_pos),?PACK_INT(6)
>>;
pack(p_monster, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_TYPE(8,p_pos),?PACK_TYPE(9,p_pos),?PACK_LIST(10,p_enemy),?PACK_LIST(11,p_enemy),?PACK_LIST(12,p_enemy),?PACK_INT(13),?PACK_INT(14),?PACK_LIST(15,p_actor_buf),?PACK_STR(16),?PACK_INT(17),?PACK_INT(18),?PACK_INT(19),?PACK_INT(20),?PACK_INT(21),?PACK_INT(22),?PACK_INT(23),?PACK_INT(24),?PACK_INT(25),?PACK_INT(26),?PACK_INT(27),?PACK_INT(28),?PACK_INT(29),?PACK_INT(30),?PACK_INT(31),?PACK_INT(32),?PACK_INT(33),?PACK_INT(34),?PACK_INT(35),?PACK_INT(36),?PACK_INT(37),?PACK_INT(38),?PACK_INT(39),?PACK_INT(40),?PACK_INT(41),?PACK_INT(42),?PACK_INT(43),?PACK_INT(44),?PACK_INT(45),?PACK_INT(46),?PACK_INT(47),?PACK_INT(48),?PACK_INT(49),?PACK_INT(50),?PACK_INT(51)
>>;
pack(p_map_monster, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_FLOAT(6),?PACK_FLOAT(7),?PACK_TYPE(8,p_pos),?PACK_FLOAT(9),?PACK_FLOAT(10),?PACK_INT(11),?PACK_TYPE(12,p_walk_path),?PACK_LIST(13,p_actor_buf),?PACK_STR(14)
>>;
pack(p_unit_base_info, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_STR(5),?PACK_INT(6),?PACK_INT(7),?PACK_INT(8),?PACK_INT(9),?PACK_INT(10),?PACK_INT(11),?PACK_LIST(12,int32)
>>;
pack(p_map_unit, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_FLOAT(5),?PACK_FLOAT(6),?PACK_TYPE(7,p_pos),?PACK_INT(8),?PACK_INT(9),?PACK_LIST(10,int32)
>>;
pack(p_boss_ai_skill, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_BOOL(6)
>>;
pack(p_mission_condition, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6),?PACK_BOOL(7),?PACK_BOOL(8)
>>;
pack(p_family_summary, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_STR(3),?PACK_INT(4),?PACK_STR(5),?PACK_INT(6),?PACK_STR(7),?PACK_INT(8),?PACK_INT(9),?PACK_INT(10),?PACK_INT(11),?PACK_INT(12),?PACK_INT(13),?PACK_INT(14),?PACK_STR(15),?PACK_INT(16),?PACK_INT(17),?PACK_INT(18)
>>;
pack(p_family_invite_info, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_STR(4),?PACK_INT(5),?PACK_STR(6)
>>;
pack(p_family_info_change, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3)
>>;
pack(p_family_info, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_STR(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6),?PACK_STR(7),?PACK_INT(8),?PACK_STR(9),?PACK_LIST(10,p_family_second_owner),?PACK_INT(11),?PACK_INT(12),?PACK_INT(13),?PACK_LIST(14,p_family_request),?PACK_LIST(15,p_family_invite),?PACK_STR(16),?PACK_STR(17),?PACK_LIST(18,p_family_member_info),?PACK_BOOL(19),?PACK_BOOL(20),?PACK_BOOL(21),?PACK_INT(22),?PACK_INT(23),?PACK_INT(24),?PACK_INT(25),?PACK_INT(26),?PACK_INT(27),?PACK_INT(28),?PACK_INT(29),?PACK_INT(30),?PACK_INT(31),?PACK_INT(32),?PACK_INT(33),?PACK_LIST(34,p_family_elder)
>>;
pack(p_family_request_info, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3)
>>;
pack(p_family_war_score, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_STR(3),?PACK_INT(4)
>>;
pack(p_family_boss, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6)
>>;
pack(p_family_member_info, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_STR(3),?PACK_STR(4),?PACK_STR(5),?PACK_INT(6),?PACK_INT(7),?PACK_INT(8),?PACK_BOOL(9),?PACK_INT(10),?PACK_INT(11),?PACK_INT(12),?PACK_INT(13)
>>;
pack(p_family_second_owner, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_STR(3)
>>;
pack(p_family_elder, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_STR(3)
>>;
pack(p_family_request, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_STR(3),?PACK_STR(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7)
>>;
pack(p_family_invite, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_STR(3),?PACK_STR(4),?PACK_INT(5)
>>;
pack(p_rank_row, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_LIST(4,string),?PACK_LIST(5,int32)
>>;
pack(p_role_family_donate_info, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_STR(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6)
>>;
pack(p_rank_element, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4)
>>;
pack(p_ranking, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_STR(5),?PACK_STR(6),?PACK_INT(7),?PACK_LIST(8,p_rank_element),?PACK_INT(9),?PACK_INT(10),?PACK_TYPE(11,p_title)
>>;
pack(p_role_level_rank, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_STR(3),?PACK_INT(4),?PACK_STR(5),?PACK_INT(6),?PACK_INT(7),?PACK_STR(8),?PACK_FLOAT(9),?PACK_INT(10),?PACK_FLOAT(11)
>>;
pack(p_role_danyao_rank, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_STR(3),?PACK_INT(4),?PACK_INT(5),?PACK_STR(6),?PACK_FLOAT(7)
>>;
pack(p_role_xfire_rank, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_STR(3),?PACK_INT(4),?PACK_INT(5),?PACK_STR(6),?PACK_FLOAT(7)
>>;
pack(p_role_pkpoint_rank, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_STR(3),?PACK_INT(4),?PACK_STR(5),?PACK_INT(6),?PACK_STR(7),?PACK_INT(8)
>>;
pack(p_family_active_rank, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_STR(3),?PACK_STR(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_INT(8),?PACK_INT(9)
>>;
pack(p_family_gongxun_rank, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_STR(3),?PACK_STR(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_INT(8),?PACK_INT(9),?PACK_INT(10),?PACK_INT(11)
>>;
pack(p_family_gongxun_persistent_rank, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6)
>>;
pack(p_equip_rank, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_STR(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_INT(8),?PACK_INT(9),?PACK_INT(10),?PACK_INT(11),?PACK_INT(12)
>>;
pack(p_role_gongxun_rank, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_STR(3),?PACK_INT(4),?PACK_STR(5),?PACK_INT(6),?PACK_INT(7),?PACK_STR(8),?PACK_FLOAT(9),?PACK_INT(10)
>>;
pack(p_role_all_rank, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_STR(3),?PACK_STR(4),?PACK_INT(5),?PACK_STR(6)
>>;
pack(p_role_give_flowers_rank, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_STR(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_STR(8),?PACK_INT(9),?PACK_STR(10)
>>;
pack(p_role_give_flowers_today_rank, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_STR(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_STR(8),?PACK_INT(9),?PACK_STR(10)
>>;
pack(p_role_give_flowers_yesterday_rank, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_STR(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_STR(8),?PACK_INT(9),?PACK_STR(10)
>>;
pack(p_role_give_flowers_last_week_rank, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_STR(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_STR(8),?PACK_INT(9),?PACK_STR(10)
>>;
pack(p_role_give_flowers_this_week_rank, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_STR(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_STR(8),?PACK_INT(9),?PACK_STR(10)
>>;
pack(p_role_rece_flowers_rank, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_STR(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_STR(8),?PACK_INT(9),?PACK_STR(10)
>>;
pack(p_role_rece_flowers_today_rank, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_STR(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_STR(8),?PACK_INT(9),?PACK_STR(10)
>>;
pack(p_role_rece_flowers_yesterday_rank, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_STR(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_STR(8),?PACK_INT(9),?PACK_STR(10)
>>;
pack(p_role_rece_flowers_last_week_rank, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_STR(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_STR(8),?PACK_INT(9),?PACK_STR(10)
>>;
pack(p_role_rece_flowers_this_week_rank, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_STR(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_STR(8),?PACK_INT(9),?PACK_STR(10)
>>;
pack(p_role_pet_rank, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_STR(3),?PACK_INT(4),?PACK_INT(5),?PACK_STR(6),?PACK_INT(7),?PACK_INT(8),?PACK_INT(9),?PACK_INT(10),?PACK_INT(11),?PACK_STR(12),?PACK_STR(13)
>>;
pack(p_mine_battle_rank, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_STR(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_INT(8),?PACK_INT(9)
>>;
pack(p_jingjie_rank, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_STR(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_INT(8)
>>;
pack(p_jingjie_rank_yesterday, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_STR(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_INT(8),?PACK_INT(9)
>>;
pack(p_role_fight_power_rank, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_STR(4),?PACK_INT(5),?PACK_FLOAT(6),?PACK_INT(7),?PACK_STR(8),?PACK_INT(9),?PACK_STR(10),?PACK_INT(11)
>>;
pack(p_role_fight_power_rank_yesterday, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_STR(4),?PACK_INT(5),?PACK_FLOAT(6),?PACK_INT(7),?PACK_STR(8),?PACK_INT(9),?PACK_INT(10)
>>;
pack(p_recommend_member_info, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_STR(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_INT(8),?PACK_INT(9)
>>;
pack(p_map_collect, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_STR(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_INT(8),?PACK_TYPE(9,p_pos),?PACK_LIST(10,p_collect_role)
>>;
pack(p_collect_role, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4)
>>;
pack(p_collect_point, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_TYPE(5,p_pos),?PACK_INT(6),?PACK_INT(7),?PACK_INT(8),?PACK_TYPE(9,p_collect_refresh),?PACK_LIST(10,int32),?PACK_INT(11),?PACK_INT(12),?PACK_LIST(13,p_collect)
>>;
pack(p_collect_point_base_info, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_TYPE(5,p_pos),?PACK_INT(6),?PACK_TYPE(7,p_collect_refresh),?PACK_INT(8),?PACK_LIST(9,p_collect)
>>;
pack(p_collect, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3)
>>;
pack(p_collect_refresh, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5)
>>;
pack(p_map_trap, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_STR(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_INT(8),?PACK_INT(9),?PACK_INT(10),?PACK_LIST(11,int32),?PACK_LIST(12,int32),?PACK_INT(13),?PACK_TYPE(14,p_pos),?PACK_INT(15),?PACK_INT(16)
>>;
pack(p_map_ybc, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_TYPE(6,p_pos),?PACK_INT(7),?PACK_STR(8),?PACK_INT(9),?PACK_INT(10),?PACK_INT(11),?PACK_INT(12),?PACK_INT(13),?PACK_LIST(14,p_actor_buf),?PACK_INT(15),?PACK_INT(16),?PACK_BOOL(17),?PACK_INT(18),?PACK_INT(19),?PACK_INT(20),?PACK_INT(21),?PACK_INT(22)
>>;
pack(p_server_npc, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_STR(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_INT(8),?PACK_INT(9),?PACK_INT(10),?PACK_INT(11),?PACK_TYPE(12,p_pos),?PACK_LIST(13,p_enemy),?PACK_LIST(14,p_enemy),?PACK_LIST(15,p_enemy),?PACK_INT(16),?PACK_INT(17),?PACK_LIST(18,p_actor_buf),?PACK_INT(19),?PACK_BOOL(20),?PACK_INT(21),?PACK_INT(22),?PACK_INT(23),?PACK_INT(24),?PACK_INT(25),?PACK_INT(26),?PACK_INT(27),?PACK_INT(28),?PACK_INT(29),?PACK_INT(30),?PACK_INT(31),?PACK_INT(32),?PACK_INT(33),?PACK_INT(34),?PACK_INT(35),?PACK_INT(36),?PACK_INT(37),?PACK_INT(38),?PACK_INT(39),?PACK_INT(40),?PACK_INT(41),?PACK_INT(42),?PACK_INT(43),?PACK_INT(44),?PACK_INT(45),?PACK_INT(46),?PACK_INT(47),?PACK_INT(48),?PACK_INT(49),?PACK_INT(50),?PACK_INT(51),?PACK_INT(52),?PACK_INT(53),?PACK_INT(54),?PACK_INT(55)
>>;
pack(p_map_server_npc, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_STR(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_INT(8),?PACK_FLOAT(9),?PACK_FLOAT(10),?PACK_INT(11),?PACK_INT(12),?PACK_TYPE(13,p_pos),?PACK_INT(14),?PACK_TYPE(15,p_walk_path),?PACK_LIST(16,p_actor_buf),?PACK_BOOL(17),?PACK_INT(18)
>>;
pack(p_server_npc_base_info, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_STR(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_INT(8),?PACK_INT(9),?PACK_INT(10),?PACK_INT(11),?PACK_INT(12),?PACK_INT(13),?PACK_INT(14),?PACK_INT(15),?PACK_INT(16),?PACK_INT(17),?PACK_INT(18),?PACK_INT(19),?PACK_INT(20),?PACK_INT(21),?PACK_INT(22),?PACK_INT(23),?PACK_INT(24),?PACK_INT(25),?PACK_INT(26),?PACK_INT(27),?PACK_INT(28),?PACK_INT(29),?PACK_INT(30),?PACK_INT(31),?PACK_BOOL(32),?PACK_INT(33),?PACK_INT(34),?PACK_INT(35),?PACK_TYPE(36,p_refresh_info),?PACK_LIST(37,p_monster_skill),?PACK_INT(38),?PACK_INT(39),?PACK_INT(40),?PACK_INT(41),?PACK_INT(42),?PACK_INT(43),?PACK_INT(44),?PACK_INT(45),?PACK_INT(46),?PACK_INT(47),?PACK_INT(48),?PACK_INT(49),?PACK_INT(50),?PACK_INT(51)
>>;
pack(p_activity_info, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7)
>>;
pack(p_activity_rank, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_STR(3),?PACK_INT(4),?PACK_INT(5),?PACK_FLOAT(6),?PACK_INT(7)
>>;
pack(p_actpoint_info, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4)
>>;
pack(p_pet_skill, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4)
>>;
pack(p_pet, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_STR(6),?PACK_INT(7),?PACK_INT(8),?PACK_STR(9),?PACK_INT(10),?PACK_INT(11),?PACK_INT(12),?PACK_LIST(13,p_actor_buf),?PACK_LIST(14,p_goods),?PACK_INT(15),?PACK_INT(16),?PACK_TYPE(17,p_fst_attr),?PACK_TYPE(18,p_sec_attr),?PACK_FLOAT(19)
>>;
pack(p_map_pet, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_STR(4),?PACK_INT(5),?PACK_INT(6),?PACK_TYPE(7,p_pos),?PACK_INT(8),?PACK_INT(9),?PACK_INT(10),?PACK_LIST(11,p_actor_buf),?PACK_INT(12),?PACK_INT(13),?PACK_BOOL(14)
>>;
pack(p_role_pet_bag, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_LIST(4,p_pet_id_name)
>>;
pack(p_pet_id_name, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_INT(8)
>>;
pack(p_present_info, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_LIST(3,p_reward_prop)
>>;
pack(p_conlogin_reward, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_INT(8),?PACK_BOOL(9),?PACK_INT(10),?PACK_INT(11),?PACK_INT(12),?PACK_BOOL(13),?PACK_INT(14),?PACK_LIST(15,int32)
>>;
pack(p_fml_buff, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3)
>>;
pack(p_role_vip, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_BOOL(6),?PACK_BOOL(7),?PACK_BOOL(8),?PACK_INT(9),?PACK_INT(10),?PACK_INT(11)
>>;
pack(p_vip_list_info, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_STR(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6),?PACK_STR(7),?PACK_INT(8),?PACK_BOOL(9)
>>;
pack(p_fmldepot_log, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_STR(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6)
>>;
pack(p_fmldepot_bag, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_LIST(3,p_goods)
>>;
pack(p_fmlshop_item, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4)
>>;
pack(p_equip_mount_renewal, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5)
>>;
pack(p_scene_war_fb_link, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_INT(8),?PACK_BOOL(9)
>>;
pack(p_gift_goods, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_BOOL(5),?PACK_INT(6),?PACK_INT(7),?PACK_INT(8),?PACK_INT(9),?PACK_INT(10)
>>;
pack(p_family_task, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3)
>>;
pack(p_treasbox_log, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_STR(4),?PACK_INT(5),?PACK_INT(6),?PACK_LIST(7,p_reward_prop)
>>;
pack(p_xfire_param, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7)
>>;
pack(p_xfire_rank, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_STR(5),?PACK_INT(6),?PACK_INT(7),?PACK_INT(8),?PACK_INT(9),?PACK_INT(10),?PACK_INT(11)
>>;
pack(p_boss_group, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_INT(8)
>>;
pack(p_reward_prop, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_BOOL(4)
>>;
pack(p_equip_item, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6)
>>;
pack(p_nationbattle_rank, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_STR(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_INT(8),?PACK_INT(9),?PACK_INT(10)
>>;
pack(p_familyboss_person_rank, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_STR(4),?PACK_INT(5),?PACK_INT(6)
>>;
pack(p_pve_fb_buff_info, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4)
>>;
pack(p_jingjie_attr_change, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_FLOAT(3)
>>;
pack(p_daily_reward, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7)
>>;
pack(p_daily_reward_item, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_BOOL(5)
>>;
pack(p_faction_strength, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3)
>>;
pack(p_activity_pay_gift_info, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_BOOL(4),?PACK_BOOL(5)
>>;
pack(p_use_item, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3)
>>;
pack(p_mystery_shop_item, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_BOOL(8),?PACK_BOOL(9),?PACK_LIST(10,p_goods)
>>;
pack(p_mystery_shop_reward, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3)
>>;
pack(p_examine_fb_panel_info, R) -><<
1:8/integer-signed,?PACK_LIST(2,int32),?PACK_LIST(3,p_examine_fb_barrier),?PACK_INT(4)
>>;
pack(p_reset_gold, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3)
>>;
pack(p_chapter_status, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5)
>>;
pack(p_examine_fb_barrier, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_LIST(5,int32)
>>;
pack(p_bet_role, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_STR(4),?PACK_INT(5)
>>;
pack(p_deposit_log, R) -><<
1:8/integer-signed,?PACK_LIST(2,p_bet_role),?PACK_INT(3),?PACK_INT(4)
>>;
pack(p_deposit_look, R) -><<
1:8/integer-signed,?PACK_STR(2),?PACK_INT(3),?PACK_INT(4)
>>;
pack(p_rnkm_role, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_INT(8)
>>;
pack(p_grab_role, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_INT(8),?PACK_INT(9),?PACK_INT(10)
>>;
pack(p_rnkm_mirror, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_STR(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_INT(8),?PACK_INT(9),?PACK_INT(10),?PACK_INT(11),?PACK_BOOL(12)
>>;
pack(p_family_pray_rec, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_STR(3),?PACK_INT(4),?PACK_INT(5)
>>;
pack(p_tili_info, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7)
>>;
pack(p_sms, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_STR(3)
>>;
pack(p_k_v, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3)
>>;
pack(p_activity_tree, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_LIST(6,int32)
>>;
pack(p_gift_reward, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_INT(8),?PACK_INT(9),?PACK_INT(10),?PACK_BOOL(11),?PACK_INT(12),?PACK_INT(13)
>>;
pack(p_activity_reward_info, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_LIST(3,p_reward_prop)
>>;
pack(p_active_attr, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_LIST(3,int32)
>>;
pack(p_activity_completion, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_LIST(4,int32),?PACK_LIST(5,p_k_v)
>>;
pack(p_role_achievement, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5)
>>;
pack(p_role_fund, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6)
>>;
pack(p_time_activity, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_LIST(6,p_activity_status),?PACK_BOOL(7)
>>;
pack(p_activity_status, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4)
>>;
pack(p_org_activity, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6)
>>;
pack(p_role_activity_daily_info, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3)
>>;
pack(p_reward_daily_info, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_BOOL(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7)
>>;
pack(p_room_info, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_LIST(4,p_room_member)
>>;
pack(p_room_member, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_STR(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6)
>>;
pack(p_func_open_info, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_BOOL(3)
>>;
pack(p_reward_fb_info, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_BOOL(3)
>>;
pack(p_open_activity, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5)
>>;
pack(p_open_activity_rank, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_STR(4),?PACK_FLOAT(5),?PACK_INT(6),?PACK_INT(7)
>>;
pack(p_daily_activity, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4)
>>;
pack(p_daily_counter, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3)
>>;
pack(p_daily_activity_guide, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4)
>>;
pack(p_daily_benefit_info, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4)
>>;
pack(p_daily_benefit_expback, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4)
>>;
pack(p_family_boss_call, R) -><<
1:8/integer-signed,?PACK_STR(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_TYPE(6,p_family_boss_reward),?PACK_TYPE(7,p_family_boss_reward),?PACK_TYPE(8,p_family_boss_reward)
>>;
pack(p_family_boss_reward, R) -><<
1:8/integer-signed,?PACK_FLOAT(2),?PACK_FLOAT(3),?PACK_INT(4),?PACK_INT(5),?PACK_TYPE(6,p_reward_prop)
>>;
pack(p_shop_sale_goods, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5)
>>;
pack(p_shop_goods_info, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_TYPE(5,p_shop_price),?PACK_TYPE(6,p_attr)
>>;
pack(p_shop_price, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4)
>>;
pack(p_secret_fb, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6)
>>;
pack(p_pet_employ, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3)
>>;
pack(p_attack_result, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_LIST(6,int32)
>>;
pack(p_prop, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3)
>>;
pack(p_lotto_his, R) -><<
1:8/integer-signed,?PACK_STR(2),?PACK_INT(3)
>>;
pack(p_danyao_hole, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_LIST(4,p_prop)
>>;
pack(p_caishen_coin, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6)
>>;
pack(p_pay_item, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_FLOAT(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6)
>>;
pack(p_round_pvp_history, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_STR(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_INT(8)
>>;
pack(p_round_pvp_rank, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_STR(4),?PACK_INT(5)
>>;
pack(p_monster_war_rank, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_STR(4),?PACK_INT(5)
>>;
pack(p_jingjie_condition, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_STR(3),?PACK_INT(4)
>>;
pack(p_gengu_info, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3)
>>;
pack(p_qq_token, R) -><<
1:8/integer-signed,?PACK_STR(2),?PACK_STR(3),?PACK_STR(4),?PACK_STR(5)
>>;
pack(p_holiday_gold_act_history, R) -><<
1:8/integer-signed,?PACK_STR(2),?PACK_INT(3),?PACK_INT(4)
>>;
pack(p_actor, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3)
>>;
pack(p_fighter, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_STR(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_INT(8),?PACK_INT(9),?PACK_INT(10),?PACK_INT(11),?PACK_INT(12),?PACK_INT(13),?PACK_LIST(14,p_role_skill),?PACK_INT(15)
>>;
pack(p_hanging_round, R) -><<
1:8/integer-signed,?PACK_TYPE(2,p_battle),?PACK_INT(3),?PACK_LIST(4,p_fighter),?PACK_LIST(5,p_fighter),?PACK_LIST(6,p_hanging_part),?PACK_INT(7),?PACK_INT(8),?PACK_INT(9),?PACK_LIST(10,int32)
>>;
pack(p_hanging_buff, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4)
>>;
pack(p_hanging_offline_report, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_INT(8),?PACK_INT(9),?PACK_INT(10),?PACK_LIST(11,p_reward_prop),?PACK_LIST(12,p_reward_color),?PACK_LIST(13,p_reward_color)
>>;
pack(p_hanging_part, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_LIST(3,p_hanging_step),?PACK_LIST(4,p_hanging_step)
>>;
pack(p_hanging_step, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_LIST(4,p_skill_result)
>>;
pack(p_skill_result, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_LIST(4,p_attack_result),?PACK_LIST(5,p_buff_result),?PACK_INT(6),?PACK_LIST(7,p_actor)
>>;
pack(p_reward_color, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3)
>>;
pack(p_battle, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4)
>>;
pack(p_fmlmatch_family_rank, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_STR(4),?PACK_INT(5)
>>;
pack(p_fmlmatch_role_rank, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_STR(4),?PACK_FLOAT(5),?PACK_INT(6)
>>;
pack(p_fmlmatch_role, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_STR(3),?PACK_INT(4),?PACK_FLOAT(5),?PACK_INT(6),?PACK_STR(7),?PACK_INT(8)
>>;
pack(p_fmlmatch_fight, R) -><<
1:8/integer-signed,?PACK_TYPE(2,p_fmlmatch_role),?PACK_TYPE(3,p_fmlmatch_role),?PACK_INT(4),?PACK_INT(5)
>>;
pack(p_role_snapshot, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_STR(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6)
>>;
pack(p_single_fb, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_BOOL(6),?PACK_INT(7)
>>;
pack(p_family_fb_rank, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_STR(5),?PACK_INT(6),?PACK_INT(7)
>>;
pack(p_buff_result, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_LIST(4,int32)
>>;
pack(p_main_fb_info, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_INT(8),?PACK_INT(9),?PACK_INT(10)
>>;
pack(p_shenqi_build, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_LIST(5,p_attr)
>>;
pack(p_moveinfo, R) -><<
1:8/integer-signed,?PACK_TYPE(2,p_pos),?PACK_TYPE(3,p_pos),?PACK_INT(4),?PACK_INT(5),?PACK_FLOAT(6),?PACK_INT(7)
>>;
pack(p_mission_listener, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_LIST(4,int32),?PACK_INT(5),?PACK_INT(6)
>>;
pack(p_mission_info, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_INT(8),?PACK_INT(9),?PACK_INT(10),?PACK_INT(11),?PACK_INT(12),?PACK_INT(13),?PACK_LIST(14,p_mission_listener),?PACK_LIST(15,int32),?PACK_LIST(16,int32),?PACK_LIST(17,int32),?PACK_LIST(18,int32)
>>;
pack(p_mission_reward_data, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_LIST(6,p_mission_prop),?PACK_INT(7)
>>;
pack(p_mission_prop, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_BOOL(5),?PACK_INT(6)
>>;
pack(p_mission_auto, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_STR(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_INT(8),?PACK_INT(9)
>>;
pack(b_server_auth_tos, R) -><<
1:8/integer-signed,?PACK_STR(2),?PACK_INT(3),?PACK_STR(4)
>>;
pack(b_server_auth_toc, R) -><<
1:8/integer-signed,?PACK_BOOL(2),?PACK_STR(3),?PACK_STR(4),?PACK_INT(5)
>>;
pack(b_server_msg_toc, R) -><<
1:8/integer-signed,?PACK_STR(2)
>>;
pack(b_server_unique_toc, R) -><<
1:8/integer-signed,?PACK_INT(2)
>>;
pack(b_consume_gold_tos, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_STR(3),?PACK_STR(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_INT(8),?PACK_INT(9),?PACK_STR(10),?PACK_INT(11),?PACK_INT(12)
>>;
pack(b_pay_log_tos, R) -><<
1:8/integer-signed,?PACK_STR(2),?PACK_STR(3),?PACK_INT(4),?PACK_STR(5),?PACK_FLOAT(6),?PACK_INT(7),?PACK_INT(8),?PACK_INT(9),?PACK_INT(10),?PACK_INT(11),?PACK_INT(12),?PACK_INT(13),?PACK_INT(14),?PACK_INT(15),?PACK_INT(16)
>>;
pack(adm_gm_complaint, R) -><<
1:8/integer-signed,?PACK_STR(2),?PACK_INT(3),?PACK_STR(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_INT(8),?PACK_STR(9),?PACK_STR(10)
>>;
pack(adm_gm_evaluate, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4)
>>;
pack(adm_gm_notify_reply, R) -><<
1:8/integer-signed,?PACK_INT(2),?PACK_BOOL(3),?PACK_STR(4)
>>;
pack(_, _) -> <<>>.

%%toc proto
pack_toc(m_common_error_toc, R) -><<
?COMMON_ERROR:32,?PACK_INT(2),?PACK_STR(3),?PACK_LIST(4,int32)
>>;
pack_toc(m_common_msg_toc, R) -><<
?COMMON_MSG:32,?PACK_STR(2)
>>;
pack_toc(m_role_auth_toc, R) -><<
?ROLE_AUTH:32,?PACK_INT(2),?PACK_STR(3),?PACK_LIST(4,p_role_info),?PACK_STR(5)
>>;
pack_toc(m_role_choose_toc, R) -><<
?ROLE_CHOOSE:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_TYPE(4,p_role),?PACK_LIST(5,p_bag_content),?PACK_TYPE(6,p_family_info),?PACK_TYPE(7,p_main_fb_info),?PACK_INT(8),?PACK_INT(9)
>>;
pack_toc(m_role_add_toc, R) -><<
?ROLE_ADD:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_INT(4)
>>;
pack_toc(m_role_gen_name_toc, R) -><<
?ROLE_GEN_NAME:32,?PACK_STR(2)
>>;
pack_toc(m_map_other_enter_toc, R) -><<
?MAP_OTHER_ENTER:32,?PACK_TYPE(2,p_map_role)
>>;
pack_toc(m_map_enter_toc, R) -><<
?MAP_ENTER:32,?PACK_BOOL(2),?PACK_BOOL(3),?PACK_STR(4),?PACK_LIST(5,p_map_role),?PACK_LIST(6,p_map_monster),?PACK_LIST(7,p_map_dropthing),?PACK_LIST(8,p_map_doll),?PACK_LIST(9,p_map_collect),?PACK_LIST(10,p_map_ybc),?PACK_TYPE(11,p_role_pos),?PACK_LIST(12,p_map_server_npc),?PACK_TYPE(13,p_map_role),?PACK_LIST(14,p_map_pet),?PACK_LIST(15,p_map_trap),?PACK_LIST(16,p_map_unit)
>>;
pack_toc(m_map_slice_enter_toc, R) -><<
?MAP_SLICE_ENTER:32,?PACK_LIST(2,p_map_role),?PACK_LIST(3,p_map_monster),?PACK_LIST(4,p_map_dropthing),?PACK_LIST(5,p_map_doll),?PACK_LIST(6,p_map_collect),?PACK_LIST(7,p_map_ybc),?PACK_BOOL(8),?PACK_LIST(9,p_map_server_npc),?PACK_LIST(10,p_map_pet),?PACK_LIST(11,p_map_trap),?PACK_LIST(12,p_map_unit),?PACK_LIST(13,int32),?PACK_LIST(14,int32),?PACK_LIST(15,int32),?PACK_LIST(16,int32),?PACK_LIST(17,int32),?PACK_LIST(18,int32),?PACK_LIST(19,int32),?PACK_LIST(20,int32),?PACK_LIST(21,int32),?PACK_LIST(22,int32),?PACK_INT(23),?PACK_TYPE(24,p_pos)
>>;
pack_toc(m_map_update_actor_mapinfo_toc, R) -><<
?MAP_UPDATE_ACTOR_MAPINFO:32,?PACK_INT(2),?PACK_INT(3),?PACK_TYPE(4,p_map_role),?PACK_TYPE(5,p_map_monster),?PACK_TYPE(6,p_map_server_npc),?PACK_TYPE(7,p_map_ybc),?PACK_TYPE(8,p_map_pet)
>>;
pack_toc(m_map_update_role_toc, R) -><<
?MAP_UPDATE_ROLE:32,?PACK_INT(2),?PACK_LIST(3,int32),?PACK_TYPE(4,p_skin),?PACK_LIST(5,p_actor_buf)
>>;
pack_toc(m_map_transfer_toc, R) -><<
?MAP_TRANSFER:32,?PACK_BOOL(2),?PACK_INT(3),?PACK_STR(4)
>>;
pack_toc(m_map_role_killed_toc, R) -><<
?MAP_ROLE_KILLED:32,?PACK_STR(2),?PACK_STR(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7)
>>;
pack_toc(m_move_info_toc, R) -><<
?MOVE_INFO:32,?PACK_INT(2),?PACK_TYPE(3,p_moveinfo)
>>;
pack_toc(m_move_walk_path_toc, R) -><<
?MOVE_WALK_PATH:32,?PACK_INT(2),?PACK_TYPE(3,p_walk_path)
>>;
pack_toc(m_move_sync_toc, R) -><<
?MOVE_SYNC:32,?PACK_INT(2),?PACK_TYPE(3,p_pos)
>>;
pack_toc(m_map_quit_toc, R) -><<
?MAP_QUIT:32,?PACK_INT(2)
>>;
pack_toc(m_map_dropthing_pick_toc, R) -><<
?MAP_DROPTHING_PICK:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_TYPE(8,p_goods),?PACK_INT(9),?PACK_INT(10)
>>;
pack_toc(m_map_change_map_toc, R) -><<
?MAP_CHANGE_MAP:32,?PACK_BOOL(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_STR(6)
>>;
pack_toc(m_map_change_pos_toc, R) -><<
?MAP_CHANGE_POS:32,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4)
>>;
pack_toc(m_fight_before_attack_toc, R) -><<
?FIGHT_BEFORE_ATTACK:32,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_LIST(6,int32)
>>;
pack_toc(m_fight_begin_toc, R) -><<
?FIGHT_BEGIN:32,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_LIST(5,int32),?PACK_INT(6),?PACK_INT(7),?PACK_INT(8)
>>;
pack_toc(m_fight_attack_toc, R) -><<
?FIGHT_ATTACK:32,?PACK_BOOL(2),?PACK_BOOL(3),?PACK_STR(4),?PACK_INT(5),?PACK_INT(6),?PACK_TYPE(7,p_pos),?PACK_INT(8),?PACK_LIST(9,p_attack_result),?PACK_INT(10),?PACK_TYPE(11,p_pos),?PACK_INT(12)
>>;
pack_toc(m_unit_enter_toc, R) -><<
?UNIT_ENTER:32,?PACK_LIST(2,p_map_unit)
>>;
pack_toc(m_unit_quit_toc, R) -><<
?UNIT_QUIT:32,?PACK_INT(2)
>>;
pack_toc(m_unit_dead_toc, R) -><<
?UNIT_DEAD:32,?PACK_STR(2),?PACK_INT(3),?PACK_INT(4)
>>;
pack_toc(m_team_invite_toc, R) -><<
?TEAM_INVITE:32,?PACK_BOOL(2),?PACK_BOOL(3),?PACK_STR(4),?PACK_INT(5),?PACK_STR(6),?PACK_INT(7),?PACK_INT(8),?PACK_INT(9),?PACK_INT(10)
>>;
pack_toc(m_team_accept_toc, R) -><<
?TEAM_ACCEPT:32,?PACK_BOOL(2),?PACK_BOOL(3),?PACK_STR(4),?PACK_LIST(5,p_team_role),?PACK_INT(6),?PACK_STR(7),?PACK_INT(8),?PACK_INT(9),?PACK_INT(10)
>>;
pack_toc(m_team_refuse_toc, R) -><<
?TEAM_REFUSE:32,?PACK_INT(2),?PACK_STR(3),?PACK_INT(4),?PACK_INT(5)
>>;
pack_toc(m_team_leave_toc, R) -><<
?TEAM_LEAVE:32,?PACK_BOOL(2),?PACK_BOOL(3),?PACK_STR(4),?PACK_LIST(5,p_team_role),?PACK_INT(6),?PACK_STR(7),?PACK_INT(8)
>>;
pack_toc(m_team_kick_toc, R) -><<
?TEAM_KICK:32,?PACK_BOOL(2),?PACK_BOOL(3),?PACK_STR(4),?PACK_LIST(5,p_team_role),?PACK_INT(6),?PACK_STR(7),?PACK_INT(8)
>>;
pack_toc(m_team_offline_toc, R) -><<
?TEAM_OFFLINE:32,?PACK_BOOL(2),?PACK_LIST(3,p_team_role),?PACK_INT(4),?PACK_STR(5),?PACK_INT(6)
>>;
pack_toc(m_team_change_leader_toc, R) -><<
?TEAM_CHANGE_LEADER:32,?PACK_BOOL(2),?PACK_BOOL(3),?PACK_STR(4),?PACK_LIST(5,p_team_role),?PACK_INT(6),?PACK_STR(7),?PACK_INT(8)
>>;
pack_toc(m_team_disband_toc, R) -><<
?TEAM_DISBAND:32,?PACK_BOOL(2),?PACK_BOOL(3),?PACK_INT(4),?PACK_STR(5)
>>;
pack_toc(m_team_pick_toc, R) -><<
?TEAM_PICK:32,?PACK_BOOL(2),?PACK_BOOL(3),?PACK_INT(4),?PACK_STR(5)
>>;
pack_toc(m_team_auto_disband_toc, R) -><<
?TEAM_AUTO_DISBAND:32,?PACK_BOOL(2),?PACK_STR(3)
>>;
pack_toc(m_team_auto_list_toc, R) -><<
?TEAM_AUTO_LIST:32,?PACK_BOOL(2),?PACK_INT(3),?PACK_LIST(4,p_team_role),?PACK_INT(5),?PACK_LIST(6,int32)
>>;
pack_toc(m_team_member_invite_toc, R) -><<
?TEAM_MEMBER_INVITE:32,?PACK_INT(2),?PACK_INT(3),?PACK_STR(4),?PACK_INT(5),?PACK_STR(6),?PACK_BOOL(7),?PACK_BOOL(8),?PACK_STR(9),?PACK_INT(10)
>>;
pack_toc(m_team_member_recommend_toc, R) -><<
?TEAM_MEMBER_RECOMMEND:32,?PACK_BOOL(2),?PACK_LIST(3,p_recommend_member_info),?PACK_STR(4)
>>;
pack_toc(m_team_apply_toc, R) -><<
?TEAM_APPLY:32,?PACK_BOOL(2),?PACK_BOOL(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6),?PACK_STR(7),?PACK_STR(8),?PACK_LIST(9,p_team_role),?PACK_INT(10),?PACK_INT(11)
>>;
pack_toc(m_team_query_toc, R) -><<
?TEAM_QUERY:32,?PACK_INT(2),?PACK_BOOL(3),?PACK_STR(4),?PACK_INT(5),?PACK_LIST(6,p_team_nearby)
>>;
pack_toc(m_team_create_toc, R) -><<
?TEAM_CREATE:32,?PACK_INT(2),?PACK_BOOL(3),?PACK_STR(4),?PACK_INT(5),?PACK_LIST(6,p_team_role),?PACK_INT(7),?PACK_INT(8)
>>;
pack_toc(m_team_fb_call_toc, R) -><<
?TEAM_FB_CALL:32,?PACK_BOOL(2),?PACK_INT(3),?PACK_STR(4),?PACK_INT(5),?PACK_INT(6),?PACK_STR(7)
>>;
pack_toc(m_team_fb_transfer_toc, R) -><<
?TEAM_FB_TRANSFER:32,?PACK_INT(2),?PACK_STR(3)
>>;
pack_toc(m_friend_request_toc, R) -><<
?FRIEND_REQUEST:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_STR(4),?PACK_BOOL(5),?PACK_BOOL(6),?PACK_TYPE(7,p_friend_info)
>>;
pack_toc(m_friend_accept_toc, R) -><<
?FRIEND_ACCEPT:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_TYPE(4,p_friend_info),?PACK_STR(5),?PACK_BOOL(6)
>>;
pack_toc(m_friend_accept_or_refuse_toc, R) -><<
?FRIEND_ACCEPT_OR_REFUSE:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_STR(4),?PACK_BOOL(5)
>>;
pack_toc(m_friend_refuse_toc, R) -><<
?FRIEND_REFUSE:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_BOOL(4),?PACK_STR(5)
>>;
pack_toc(m_friend_delete_toc, R) -><<
?FRIEND_DELETE:32,?PACK_BOOL(2),?PACK_INT(3),?PACK_STR(4),?PACK_BOOL(5),?PACK_INT(6)
>>;
pack_toc(m_friend_black_toc, R) -><<
?FRIEND_BLACK:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_TYPE(4,p_friend_info),?PACK_STR(5),?PACK_BOOL(6)
>>;
pack_toc(m_friend_enemy_toc, R) -><<
?FRIEND_ENEMY:32,?PACK_TYPE(2,p_friend_info)
>>;
pack_toc(m_friend_list_toc, R) -><<
?FRIEND_LIST:32,?PACK_BOOL(2),?PACK_LIST(3,p_friend_info),?PACK_STR(4),?PACK_INT(5),?PACK_INT(6)
>>;
pack_toc(m_friend_black_list_toc, R) -><<
?FRIEND_BLACK_LIST:32,?PACK_LIST(2,p_friend_info)
>>;
pack_toc(m_friend_black_delete_toc, R) -><<
?FRIEND_BLACK_DELETE:32,?PACK_INT(2),?PACK_BOOL(3),?PACK_STR(4)
>>;
pack_toc(m_friend_search_toc, R) -><<
?FRIEND_SEARCH:32,?PACK_LIST(2,p_friend_info)
>>;
pack_toc(m_friend_around_role_toc, R) -><<
?FRIEND_AROUND_ROLE:32,?PACK_LIST(2,p_friend_info)
>>;
pack_toc(m_friend_recent_contacts_toc, R) -><<
?FRIEND_RECENT_CONTACTS:32,?PACK_LIST(2,p_friend_info)
>>;
pack_toc(m_friend_offline_request_toc, R) -><<
?FRIEND_OFFLINE_REQUEST:32,?PACK_LIST(2,p_friend_info)
>>;
pack_toc(m_friend_request_list_toc, R) -><<
?FRIEND_REQUEST_LIST:32,?PACK_LIST(2,p_friend_info)
>>;
pack_toc(m_friend_change_relative_toc, R) -><<
?FRIEND_CHANGE_RELATIVE:32,?PACK_INT(2),?PACK_LIST(3,int32)
>>;
pack_toc(m_friend_add_friendly_toc, R) -><<
?FRIEND_ADD_FRIENDLY:32,?PACK_INT(2),?PACK_INT(3)
>>;
pack_toc(m_friend_online_toc, R) -><<
?FRIEND_ONLINE:32,?PACK_INT(2)
>>;
pack_toc(m_friend_offline_toc, R) -><<
?FRIEND_OFFLINE:32,?PACK_INT(2)
>>;
pack_toc(m_friend_upgrade_toc, R) -><<
?FRIEND_UPGRADE:32,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4)
>>;
pack_toc(m_friend_info_toc, R) -><<
?FRIEND_INFO:32,?PACK_BOOL(2),?PACK_TYPE(3,p_role_ext),?PACK_STR(4),?PACK_LIST(5,p_goods)
>>;
pack_toc(m_friend_modify_toc, R) -><<
?FRIEND_MODIFY:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_BOOL(4),?PACK_TYPE(5,p_role_ext)
>>;
pack_toc(m_friend_create_family_toc, R) -><<
?FRIEND_CREATE_FAMILY:32,?PACK_INT(2),?PACK_INT(3),?PACK_STR(4)
>>;
pack_toc(m_friend_get_info_toc, R) -><<
?FRIEND_GET_INFO:32,?PACK_TYPE(2,p_friend_info)
>>;
pack_toc(m_friend_update_family_toc, R) -><<
?FRIEND_UPDATE_FAMILY:32,?PACK_INT(2),?PACK_INT(3),?PACK_STR(4),?PACK_INT(5)
>>;
pack_toc(m_friend_recommend_toc, R) -><<
?FRIEND_RECOMMEND:32,?PACK_INT(2),?PACK_BOOL(3),?PACK_LIST(4,p_recommend_member_info),?PACK_STR(5)
>>;
pack_toc(m_friend_auto_recommend_toc, R) -><<
?FRIEND_AUTO_RECOMMEND:32,?PACK_BOOL(2),?PACK_LIST(3,p_recommend_member_info),?PACK_STR(4)
>>;
pack_toc(m_friend_quick_request_toc, R) -><<
?FRIEND_QUICK_REQUEST:32,?PACK_INT(2),?PACK_STR(3),?PACK_BOOL(4),?PACK_STR(5)
>>;
pack_toc(m_friend_congratulation_toc, R) -><<
?FRIEND_CONGRATULATION:32,?PACK_BOOL(2),?PACK_BOOL(3),?PACK_STR(4),?PACK_INT(5),?PACK_INT(6),?PACK_STR(7),?PACK_STR(8)
>>;
pack_toc(m_friend_advertise_toc, R) -><<
?FRIEND_ADVERTISE:32,?PACK_BOOL(2),?PACK_STR(3)
>>;
pack_toc(m_friend_send_letter_toc, R) -><<
?FRIEND_SEND_LETTER:32,?PACK_STR(2)
>>;
pack_toc(m_letter_get_toc, R) -><<
?LETTER_GET:32,?PACK_LIST(2,p_letter_simple_info),?PACK_INT(3)
>>;
pack_toc(m_letter_open_toc, R) -><<
?LETTER_OPEN:32,?PACK_BOOL(2),?PACK_TYPE(3,p_letter_info),?PACK_STR(4)
>>;
pack_toc(m_letter_send_toc, R) -><<
?LETTER_SEND:32,?PACK_BOOL(2),?PACK_TYPE(3,p_letter_simple_info),?PACK_STR(4)
>>;
pack_toc(m_letter_delete_toc, R) -><<
?LETTER_DELETE:32,?PACK_BOOL(2),?PACK_LIST(3,p_letter_delete),?PACK_STR(4)
>>;
pack_toc(m_letter_accept_goods_toc, R) -><<
?LETTER_ACCEPT_GOODS:32,?PACK_BOOL(2),?PACK_INT(3),?PACK_LIST(4,p_reward_prop),?PACK_LIST(5,p_goods),?PACK_STR(6)
>>;
pack_toc(m_mount_list_toc, R) -><<
?MOUNT_LIST:32,?PACK_LIST(2,p_mount_info)
>>;
pack_toc(m_mount_up_toc, R) -><<
?MOUNT_UP:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_TYPE(4,p_mount_info)
>>;
pack_toc(m_mount_down_toc, R) -><<
?MOUNT_DOWN:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_TYPE(4,p_mount_info)
>>;
pack_toc(m_mount_upgrade_toc, R) -><<
?MOUNT_UPGRADE:32,?PACK_BOOL(2),?PACK_BOOL(3),?PACK_STR(4),?PACK_TYPE(5,p_mount_info)
>>;
pack_toc(m_mount_autoupgrade_toc, R) -><<
?MOUNT_AUTOUPGRADE:32,?PACK_INT(2),?PACK_STR(3),?PACK_TYPE(4,p_mount_info),?PACK_INT(5)
>>;
pack_toc(m_mount_changeup_toc, R) -><<
?MOUNT_CHANGEUP:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_TYPE(4,p_mount_info)
>>;
pack_toc(m_mount_changedown_toc, R) -><<
?MOUNT_CHANGEDOWN:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_TYPE(4,p_mount_info)
>>;
pack_toc(m_mount_forceup_toc, R) -><<
?MOUNT_FORCEUP:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_TYPE(4,p_mount_info)
>>;
pack_toc(m_mount_forcedown_toc, R) -><<
?MOUNT_FORCEDOWN:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_TYPE(4,p_mount_info)
>>;
pack_toc(m_mount_evolve_toc, R) -><<
?MOUNT_EVOLVE:32,?PACK_TYPE(2,p_mount_info),?PACK_TYPE(3,p_mount_info)
>>;
pack_toc(m_fashion_list_toc, R) -><<
?FASHION_LIST:32,?PACK_LIST(2,p_mount_info)
>>;
pack_toc(m_fashion_up_toc, R) -><<
?FASHION_UP:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_TYPE(4,p_mount_info)
>>;
pack_toc(m_fashion_down_toc, R) -><<
?FASHION_DOWN:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_TYPE(4,p_mount_info)
>>;
pack_toc(m_fashion_upgrade_toc, R) -><<
?FASHION_UPGRADE:32,?PACK_BOOL(2),?PACK_BOOL(3),?PACK_STR(4),?PACK_TYPE(5,p_mount_info)
>>;
pack_toc(m_fashion_autoupgrade_toc, R) -><<
?FASHION_AUTOUPGRADE:32,?PACK_INT(2),?PACK_STR(3),?PACK_TYPE(4,p_mount_info),?PACK_INT(5)
>>;
pack_toc(m_equip_mountup_toc, R) -><<
?EQUIP_MOUNTUP:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_TYPE(4,p_goods),?PACK_TYPE(5,p_goods)
>>;
pack_toc(m_equip_mountdown_toc, R) -><<
?EQUIP_MOUNTDOWN:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_TYPE(4,p_goods)
>>;
pack_toc(m_equip_mount_changecolor_toc, R) -><<
?EQUIP_MOUNT_CHANGECOLOR:32,?PACK_BOOL(2),?PACK_BOOL(3),?PACK_STR(4),?PACK_INT(5),?PACK_INT(6),?PACK_TYPE(7,p_goods)
>>;
pack_toc(m_equip_load_toc, R) -><<
?EQUIP_LOAD:32,?PACK_INT(2),?PACK_BOOL(3),?PACK_STR(4),?PACK_TYPE(5,p_goods),?PACK_TYPE(6,p_goods)
>>;
pack_toc(m_equip_unload_toc, R) -><<
?EQUIP_UNLOAD:32,?PACK_INT(2),?PACK_BOOL(3),?PACK_STR(4),?PACK_TYPE(5,p_goods),?PACK_INT(6)
>>;
pack_toc(m_equip_update_toc, R) -><<
?EQUIP_UPDATE:32,?PACK_INT(2),?PACK_LIST(3,p_goods)
>>;
pack_toc(m_equip_reinforce_toc, R) -><<
?EQUIP_REINFORCE:32,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6)
>>;
pack_toc(m_equip_inherit_toc, _R) -><<
?EQUIP_INHERIT:32>>;
pack_toc(m_item_use_toc, R) -><<
?ITEM_USE:32,?PACK_BOOL(2),?PACK_LIST(3,string),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7)
>>;
pack_toc(m_item_use_special_toc, R) -><<
?ITEM_USE_SPECIAL:32,?PACK_INT(2),?PACK_BOOL(3),?PACK_STR(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_INT(8),?PACK_LIST(9,p_item_effect),?PACK_LIST(10,p_goods),?PACK_STR(11)
>>;
pack_toc(m_item_trace_toc, R) -><<
?ITEM_TRACE:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_INT(4),?PACK_INT(5),?PACK_STR(6),?PACK_INT(7),?PACK_INT(8),?PACK_INT(9)
>>;
pack_toc(m_item_extend_bag_row_toc, R) -><<
?ITEM_EXTEND_BAG_ROW:32,?PACK_BOOL(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7)
>>;
pack_toc(m_item_gift_toc, R) -><<
?ITEM_GIFT:32,?PACK_LIST(2,p_reward_prop)
>>;
pack_toc(m_goods_destroy_toc, R) -><<
?GOODS_DESTROY:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_INT(4)
>>;
pack_toc(m_goods_sale_toc, R) -><<
?GOODS_SALE:32,?PACK_INT(2),?PACK_STR(3),?PACK_INT(4),?PACK_INT(5)
>>;
pack_toc(m_goods_swap_toc, R) -><<
?GOODS_SWAP:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_TYPE(4,p_goods),?PACK_TYPE(5,p_goods)
>>;
pack_toc(m_goods_divide_toc, R) -><<
?GOODS_DIVIDE:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_TYPE(4,p_goods),?PACK_TYPE(5,p_goods)
>>;
pack_toc(m_goods_update_toc, R) -><<
?GOODS_UPDATE:32,?PACK_LIST(2,int32),?PACK_LIST(3,p_goods)
>>;
pack_toc(m_goods_tidy_toc, R) -><<
?GOODS_TIDY:32,?PACK_INT(2),?PACK_LIST(3,p_goods)
>>;
pack_toc(m_goods_show_goods_toc, R) -><<
?GOODS_SHOW_GOODS:32,?PACK_BOOL(2),?PACK_STR(3)
>>;
pack_toc(m_role2_hpmp_change_toc, R) -><<
?ROLE2_HPMP_CHANGE:32,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4)
>>;
pack_toc(m_role2_levelup_toc, R) -><<
?ROLE2_LEVELUP:32,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6),?PACK_FLOAT(7),?PACK_FLOAT(8),?PACK_FLOAT(9)
>>;
pack_toc(m_role2_levelup_other_toc, R) -><<
?ROLE2_LEVELUP_OTHER:32,?PACK_INT(2),?PACK_INT(3)
>>;
pack_toc(m_role2_attr_change_toc, R) -><<
?ROLE2_ATTR_CHANGE:32,?PACK_INT(2),?PACK_LIST(3,p_role_attr_change)
>>;
pack_toc(m_role2_base_reload_toc, R) -><<
?ROLE2_BASE_RELOAD:32,?PACK_TYPE(2,p_role_base),?PACK_FLOAT(3)
>>;
pack_toc(m_role2_dead_toc, R) -><<
?ROLE2_DEAD:32,?PACK_STR(2),?PACK_LIST(3,int32),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6)
>>;
pack_toc(m_role2_dead_other_toc, R) -><<
?ROLE2_DEAD_OTHER:32,?PACK_INT(2)
>>;
pack_toc(m_role2_relive_toc, R) -><<
?ROLE2_RELIVE:32,?PACK_BOOL(2),?PACK_BOOL(3),?PACK_STR(4),?PACK_TYPE(5,p_role_fight),?PACK_TYPE(6,p_role_pos),?PACK_TYPE(7,p_map_role),?PACK_BOOL(8)
>>;
pack_toc(m_role2_unbund_change_toc, R) -><<
?ROLE2_UNBUND_CHANGE:32,?PACK_BOOL(2)
>>;
pack_toc(m_role2_getroleattr_toc, R) -><<
?ROLE2_GETROLEATTR:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_TYPE(4,p_other_role_info),?PACK_TYPE(5,p_role_pet_bag),?PACK_LIST(6,p_pet)
>>;
pack_toc(m_role2_pkmodemodify_toc, R) -><<
?ROLE2_PKMODEMODIFY:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_INT(4)
>>;
pack_toc(m_role2_show_equip_ring_toc, R) -><<
?ROLE2_SHOW_EQUIP_RING:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_BOOL(4)
>>;
pack_toc(m_role2_sex_toc, R) -><<
?ROLE2_SEX:32,?PACK_BOOL(2),?PACK_INT(3),?PACK_STR(4)
>>;
pack_toc(m_role2_remove_skin_buff_toc, R) -><<
?ROLE2_REMOVE_SKIN_BUFF:32,?PACK_BOOL(2),?PACK_STR(3)
>>;
pack_toc(m_role2_online_broadcast_toc, R) -><<
?ROLE2_ONLINE_BROADCAST:32,?PACK_INT(2),?PACK_STR(3),?PACK_INT(4)
>>;
pack_toc(m_role2_rename_toc, R) -><<
?ROLE2_RENAME:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_INT(4)
>>;
pack_toc(m_role2_buy_tili_toc, R) -><<
?ROLE2_BUY_TILI:32,?PACK_INT(2),?PACK_STR(3),?PACK_TYPE(4,p_tili_info)
>>;
pack_toc(m_role2_tili_info_toc, R) -><<
?ROLE2_TILI_INFO:32,?PACK_TYPE(2,p_tili_info)
>>;
pack_toc(m_role2_daily_present_toc, R) -><<
?ROLE2_DAILY_PRESENT:32,?PACK_INT(2)
>>;
pack_toc(m_monster_enter_toc, R) -><<
?MONSTER_ENTER:32,?PACK_LIST(2,p_map_monster)
>>;
pack_toc(m_monster_quit_toc, R) -><<
?MONSTER_QUIT:32,?PACK_INT(2)
>>;
pack_toc(m_monster_dead_toc, R) -><<
?MONSTER_DEAD:32,?PACK_STR(2),?PACK_INT(3),?PACK_INT(4)
>>;
pack_toc(m_monster_attr_change_toc, R) -><<
?MONSTER_ATTR_CHANGE:32,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4)
>>;
pack_toc(m_monster_walk_path_toc, R) -><<
?MONSTER_WALK_PATH:32,?PACK_INT(2),?PACK_TYPE(3,p_walk_path)
>>;
pack_toc(m_monster_walk_toc, R) -><<
?MONSTER_WALK:32,?PACK_TYPE(2,p_map_monster),?PACK_TYPE(3,p_pos)
>>;
pack_toc(m_monster_summon_toc, R) -><<
?MONSTER_SUMMON:32,?PACK_INT(2)
>>;
pack_toc(m_monster_talk_toc, R) -><<
?MONSTER_TALK:32,?PACK_INT(2),?PACK_INT(3),?PACK_STR(4)
>>;
pack_toc(m_monster_skill_toc, R) -><<
?MONSTER_SKILL:32,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6)
>>;
pack_toc(m_exchange_deal_item_toc, R) -><<
?EXCHANGE_DEAL_ITEM:32,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_STR(6)
>>;
pack_toc(m_exchange_deal_score_toc, R) -><<
?EXCHANGE_DEAL_SCORE:32,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4)
>>;
pack_toc(m_skill_list_toc, R) -><<
?SKILL_LIST:32,?PACK_INT(2),?PACK_LIST(3,p_role_skill),?PACK_LIST(4,p_role_skill),?PACK_LIST(5,p_role_skill),?PACK_LIST(6,p_role_skill),?PACK_INT(7),?PACK_INT(8)
>>;
pack_toc(m_depot_get_goods_toc, R) -><<
?DEPOT_GET_GOODS:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_INT(4),?PACK_INT(5),?PACK_LIST(6,p_depot_bag)
>>;
pack_toc(m_depot_dredge_toc, R) -><<
?DEPOT_DREDGE:32,?PACK_BOOL(2),?PACK_INT(3),?PACK_STR(4)
>>;
pack_toc(m_depot_destroy_toc, R) -><<
?DEPOT_DESTROY:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_INT(4)
>>;
pack_toc(m_depot_swap_toc, R) -><<
?DEPOT_SWAP:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_TYPE(4,p_goods),?PACK_TYPE(5,p_goods)
>>;
pack_toc(m_depot_divide_toc, R) -><<
?DEPOT_DIVIDE:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_TYPE(4,p_goods),?PACK_TYPE(5,p_goods)
>>;
pack_toc(m_depot_tidy_toc, R) -><<
?DEPOT_TIDY:32,?PACK_BOOL(2),?PACK_INT(3),?PACK_LIST(4,p_goods)
>>;
pack_toc(m_depot_extend_row_toc, R) -><<
?DEPOT_EXTEND_ROW:32,?PACK_BOOL(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5)
>>;
pack_toc(m_shortcut_init_toc, R) -><<
?SHORTCUT_INIT:32,?PACK_LIST(2,p_shortcut),?PACK_INT(3)
>>;
pack_toc(m_bubble_send_toc, R) -><<
?BUBBLE_SEND:32,?PACK_BOOL(2),?PACK_STR(3)
>>;
pack_toc(m_bubble_msg_toc, R) -><<
?BUBBLE_MSG:32,?PACK_INT(2),?PACK_INT(3),?PACK_STR(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_STR(8),?PACK_INT(9),?PACK_INT(10)
>>;
pack_toc(m_family_create_toc, R) -><<
?FAMILY_CREATE:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_TYPE(4,p_family_info),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_INT(8)
>>;
pack_toc(m_family_self_toc, R) -><<
?FAMILY_SELF:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_TYPE(4,p_family_info),?PACK_INT(5)
>>;
pack_toc(m_family_panel_toc, R) -><<
?FAMILY_PANEL:32,?PACK_LIST(2,p_family_invite_info),?PACK_LIST(3,p_family_summary),?PACK_LIST(4,p_family_request_info),?PACK_INT(5)
>>;
pack_toc(m_family_enter_map_toc, R) -><<
?FAMILY_ENTER_MAP:32,?PACK_BOOL(2),?PACK_STR(3)
>>;
pack_toc(m_family_boss_info_toc, R) -><<
?FAMILY_BOSS_INFO:32,?PACK_LIST(2,p_family_boss_call)
>>;
pack_toc(m_family_boss_call_toc, R) -><<
?FAMILY_BOSS_CALL:32,?PACK_INT(2),?PACK_STR(3),?PACK_INT(4),?PACK_TYPE(5,p_family_boss_call)
>>;
pack_toc(m_family_boss_notice_toc, _R) -><<
?FAMILY_BOSS_NOTICE:32>>;
pack_toc(m_family_boss_attack_toc, R) -><<
?FAMILY_BOSS_ATTACK:32,?PACK_STR(2),?PACK_INT(3),?PACK_INT(4),?PACK_STR(5),?PACK_INT(6),?PACK_BOOL(7),?PACK_INT(8)
>>;
pack_toc(m_family_boss_reward_toc, R) -><<
?FAMILY_BOSS_REWARD:32,?PACK_TYPE(2,p_family_boss_reward),?PACK_BOOL(3)
>>;
pack_toc(m_family_call_partyboss_toc, R) -><<
?FAMILY_CALL_PARTYBOSS:32,?PACK_BOOL(2),?PACK_STR(3)
>>;
pack_toc(m_family_uplevel_toc, R) -><<
?FAMILY_UPLEVEL:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_BOOL(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7)
>>;
pack_toc(m_family_request_list_toc, R) -><<
?FAMILY_REQUEST_LIST:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_LIST(4,p_family_request)
>>;
pack_toc(m_family_member_join_toc, R) -><<
?FAMILY_MEMBER_JOIN:32,?PACK_TYPE(2,p_family_member_info)
>>;
pack_toc(m_family_list_toc, R) -><<
?FAMILY_LIST:32,?PACK_LIST(2,p_family_summary),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5)
>>;
pack_toc(m_family_join_limit_toc, R) -><<
?FAMILY_JOIN_LIMIT:32,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4)
>>;
pack_toc(m_family_request_toc, R) -><<
?FAMILY_REQUEST:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_BOOL(4),?PACK_TYPE(5,p_family_request),?PACK_INT(6)
>>;
pack_toc(m_family_backout_toc, R) -><<
?FAMILY_BACKOUT:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_INT(4)
>>;
pack_toc(m_family_invite_toc, R) -><<
?FAMILY_INVITE:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_BOOL(4),?PACK_STR(5),?PACK_INT(6),?PACK_STR(7)
>>;
pack_toc(m_family_cancel_invite_toc, R) -><<
?FAMILY_CANCEL_INVITE:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_BOOL(4),?PACK_INT(5)
>>;
pack_toc(m_family_refuse_toc, R) -><<
?FAMILY_REFUSE:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_BOOL(4),?PACK_INT(5),?PACK_STR(6)
>>;
pack_toc(m_family_agree_f_toc, R) -><<
?FAMILY_AGREE_F:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_BOOL(4),?PACK_TYPE(5,p_family_info),?PACK_INT(6)
>>;
pack_toc(m_family_dismiss_toc, R) -><<
?FAMILY_DISMISS:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_BOOL(4)
>>;
pack_toc(m_family_set_title_toc, R) -><<
?FAMILY_SET_TITLE:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_BOOL(4),?PACK_INT(5),?PACK_STR(6),?PACK_STR(7)
>>;
pack_toc(m_family_set_owner_toc, R) -><<
?FAMILY_SET_OWNER:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_BOOL(4),?PACK_INT(5),?PACK_TYPE(6,p_family_info)
>>;
pack_toc(m_family_set_secowner_or_elder_toc, R) -><<
?FAMILY_SET_SECOWNER_OR_ELDER:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_BOOL(4),?PACK_INT(5),?PACK_STR(6),?PACK_TYPE(7,p_family_info),?PACK_INT(8)
>>;
pack_toc(m_family_unset_secowner_or_elder_toc, R) -><<
?FAMILY_UNSET_SECOWNER_OR_ELDER:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_BOOL(4),?PACK_INT(5),?PACK_TYPE(6,p_family_info),?PACK_INT(7)
>>;
pack_toc(m_family_update_notice_toc, R) -><<
?FAMILY_UPDATE_NOTICE:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_BOOL(4),?PACK_STR(5),?PACK_STR(6)
>>;
pack_toc(m_family_refuse_f_toc, R) -><<
?FAMILY_REFUSE_F:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_BOOL(4),?PACK_STR(5),?PACK_INT(6)
>>;
pack_toc(m_family_fire_toc, R) -><<
?FAMILY_FIRE:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_BOOL(4),?PACK_INT(5),?PACK_STR(6)
>>;
pack_toc(m_family_agree_toc, R) -><<
?FAMILY_AGREE:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_BOOL(4),?PACK_TYPE(5,p_family_member_info),?PACK_TYPE(6,p_family_info)
>>;
pack_toc(m_family_leave_toc, R) -><<
?FAMILY_LEAVE:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_STR(4),?PACK_BOOL(5),?PACK_INT(6)
>>;
pack_toc(m_family_leave_map_toc, R) -><<
?FAMILY_LEAVE_MAP:32,?PACK_BOOL(2),?PACK_STR(3)
>>;
pack_toc(m_family_role_online_toc, R) -><<
?FAMILY_ROLE_ONLINE:32,?PACK_INT(2)
>>;
pack_toc(m_family_role_offline_toc, R) -><<
?FAMILY_ROLE_OFFLINE:32,?PACK_INT(2)
>>;
pack_toc(m_family_can_invite_toc, R) -><<
?FAMILY_CAN_INVITE:32,?PACK_LIST(2,p_recommend_member_info)
>>;
pack_toc(m_family_cancel_title_toc, R) -><<
?FAMILY_CANCEL_TITLE:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_INT(4)
>>;
pack_toc(m_family_enable_map_toc, R) -><<
?FAMILY_ENABLE_MAP:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_BOOL(4)
>>;
pack_toc(m_family_del_request_toc, R) -><<
?FAMILY_DEL_REQUEST:32,?PACK_INT(2)
>>;
pack_toc(m_family_map_closed_toc, _R) -><<
?FAMILY_MAP_CLOSED:32>>;
pack_toc(m_family_info_change_toc, R) -><<
?FAMILY_INFO_CHANGE:32,?PACK_LIST(2,p_family_info_change)
>>;
pack_toc(m_family_active_points_toc, R) -><<
?FAMILY_ACTIVE_POINTS:32,?PACK_INT(2)
>>;
pack_toc(m_family_money_toc, R) -><<
?FAMILY_MONEY:32,?PACK_INT(2)
>>;
pack_toc(m_family_downlevel_toc, R) -><<
?FAMILY_DOWNLEVEL:32,?PACK_INT(2),?PACK_STR(3)
>>;
pack_toc(m_family_callmember_toc, R) -><<
?FAMILY_CALLMEMBER:32,?PACK_INT(2),?PACK_BOOL(3),?PACK_STR(4),?PACK_STR(5)
>>;
pack_toc(m_family_member_enter_map_toc, R) -><<
?FAMILY_MEMBER_ENTER_MAP:32,?PACK_BOOL(2),?PACK_STR(3)
>>;
pack_toc(m_family_maintainfail_toc, R) -><<
?FAMILY_MAINTAINFAIL:32,?PACK_STR(2),?PACK_INT(3),?PACK_INT(4)
>>;
pack_toc(m_family_activestate_toc, R) -><<
?FAMILY_ACTIVESTATE:32,?PACK_BOOL(2),?PACK_LIST(3,p_family_task)
>>;
pack_toc(m_family_membergather_toc, R) -><<
?FAMILY_MEMBERGATHER:32,?PACK_STR(2)
>>;
pack_toc(m_family_gatherrequest_toc, R) -><<
?FAMILY_GATHERREQUEST:32,?PACK_BOOL(2),?PACK_STR(3)
>>;
pack_toc(m_family_detail_toc, R) -><<
?FAMILY_DETAIL:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_TYPE(4,p_family_info)
>>;
pack_toc(m_family_set_bonfire_start_time_toc, R) -><<
?FAMILY_SET_BONFIRE_START_TIME:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6)
>>;
pack_toc(m_family_get_donate_info_toc, R) -><<
?FAMILY_GET_DONATE_INFO:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_INT(4),?PACK_LIST(5,p_role_family_donate_info),?PACK_LIST(6,p_role_family_donate_info)
>>;
pack_toc(m_family_donate_toc, R) -><<
?FAMILY_DONATE:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_INT(4),?PACK_INT(5),?PACK_TYPE(6,p_role_family_donate_info)
>>;
pack_toc(m_family_auto_agree_toc, R) -><<
?FAMILY_AUTO_AGREE:32,?PACK_INT(2),?PACK_INT(3)
>>;
pack_toc(m_fmlbonus_list_toc, R) -><<
?FMLBONUS_LIST:32,?PACK_LIST(2,p_family_bonus)
>>;
pack_toc(m_fmlbonus_donate_toc, R) -><<
?FMLBONUS_DONATE:32,?PACK_LIST(2,p_family_bonus),?PACK_INT(3)
>>;
pack_toc(m_fmlbonus_send_toc, R) -><<
?FMLBONUS_SEND:32,?PACK_INT(2)
>>;
pack_toc(m_fmlbonus_send_history_toc, R) -><<
?FMLBONUS_SEND_HISTORY:32,?PACK_LIST(2,int32)
>>;
pack_toc(m_fmlbonus_get_toc, R) -><<
?FMLBONUS_GET:32,?PACK_LIST(2,p_family_bonus),?PACK_INT(3)
>>;
pack_toc(m_broadcast_general_toc, R) -><<
?BROADCAST_GENERAL:32,?PACK_LIST(2,int32),?PACK_INT(3),?PACK_STR(4),?PACK_LIST(5,string)
>>;
pack_toc(m_broadcast_countdown_toc, R) -><<
?BROADCAST_COUNTDOWN:32,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_STR(5),?PACK_INT(6),?PACK_INT(7)
>>;
pack_toc(m_broadcast_laba_toc, R) -><<
?BROADCAST_LABA:32,?PACK_BOOL(2),?PACK_BOOL(3),?PACK_STR(4),?PACK_STR(5),?PACK_INT(6),?PACK_STR(7),?PACK_INT(8),?PACK_INT(9)
>>;
pack_toc(m_broadcast_stop_toc, R) -><<
?BROADCAST_STOP:32,?PACK_INT(2),?PACK_STR(3)
>>;
pack_toc(m_equip_del_toc, R) -><<
?EQUIP_DEL:32,?PACK_INT(2),?PACK_LIST(3,int32),?PACK_TYPE(4,p_goods),?PACK_TYPE(5,p_skin)
>>;
pack_toc(m_system_heartbeat_toc, R) -><<
?SYSTEM_HEARTBEAT:32,?PACK_INT(2),?PACK_INT(3)
>>;
pack_toc(m_system_fcm_toc, R) -><<
?SYSTEM_FCM:32,?PACK_STR(2),?PACK_INT(3),?PACK_INT(4)
>>;
pack_toc(m_system_error_toc, R) -><<
?SYSTEM_ERROR:32,?PACK_STR(2),?PACK_INT(3)
>>;
pack_toc(m_system_message_toc, R) -><<
?SYSTEM_MESSAGE:32,?PACK_STR(2)
>>;
pack_toc(m_system_config_change_toc, R) -><<
?SYSTEM_CONFIG_CHANGE:32,?PACK_BOOL(2),?PACK_STR(3)
>>;
pack_toc(m_system_config_toc, R) -><<
?SYSTEM_CONFIG:32,?PACK_TYPE(2,p_sys_config)
>>;
pack_toc(m_system_setting_toc, R) -><<
?SYSTEM_SETTING:32,?PACK_BOOL(2),?PACK_BOOL(3),?PACK_BOOL(4),?PACK_BOOL(5),?PACK_INT(6),?PACK_STR(7),?PACK_STR(8),?PACK_STR(9),?PACK_STR(10),?PACK_STR(11)
>>;
pack_toc(m_system_pay_toc, R) -><<
?SYSTEM_PAY:32,?PACK_LIST(2,p_pay_item)
>>;
pack_toc(m_gm_complaint_toc, R) -><<
?GM_COMPLAINT:32,?PACK_BOOL(2),?PACK_STR(3)
>>;
pack_toc(m_gm_score_toc, R) -><<
?GM_SCORE:32,?PACK_BOOL(2),?PACK_STR(3)
>>;
pack_toc(m_ranking_get_rank_toc, R) -><<
?RANKING_GET_RANK:32,?PACK_INT(2),?PACK_LIST(3,p_rank_row),?PACK_INT(4)
>>;
pack_toc(m_ranking_role_all_rank_toc, R) -><<
?RANKING_ROLE_ALL_RANK:32,?PACK_LIST(2,p_role_all_rank),?PACK_INT(3),?PACK_STR(4),?PACK_BOOL(5)
>>;
pack_toc(m_title_get_role_titles_toc, R) -><<
?TITLE_GET_ROLE_TITLES:32,?PACK_LIST(2,p_title)
>>;
pack_toc(m_title_change_cur_title_toc, R) -><<
?TITLE_CHANGE_CUR_TITLE:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_STR(4),?PACK_INT(5)
>>;
pack_toc(m_family_memberuplevel_toc, R) -><<
?FAMILY_MEMBERUPLEVEL:32,?PACK_INT(2),?PACK_INT(3)
>>;
pack_toc(m_server_npc_enter_toc, R) -><<
?SERVER_NPC_ENTER:32,?PACK_LIST(2,p_map_server_npc)
>>;
pack_toc(m_server_npc_quit_toc, R) -><<
?SERVER_NPC_QUIT:32,?PACK_LIST(2,int32)
>>;
pack_toc(m_server_npc_dead_toc, R) -><<
?SERVER_NPC_DEAD:32,?PACK_INT(2)
>>;
pack_toc(m_activity_today_toc, R) -><<
?ACTIVITY_TODAY:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_LIST(4,p_activity_info)
>>;
pack_toc(m_activity_today_update_toc, R) -><<
?ACTIVITY_TODAY_UPDATE:32,?PACK_TYPE(2,p_activity_info)
>>;
pack_toc(m_activity_pay_gift_info_toc, R) -><<
?ACTIVITY_PAY_GIFT_INFO:32,?PACK_INT(2),?PACK_STR(3),?PACK_INT(4),?PACK_LIST(5,p_activity_pay_gift_info)
>>;
pack_toc(m_activity_getgift_toc, R) -><<
?ACTIVITY_GETGIFT:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_INT(4),?PACK_INT(5)
>>;
pack_toc(m_activity_completion_info_toc, R) -><<
?ACTIVITY_COMPLETION_INFO:32,?PACK_INT(2),?PACK_STR(3),?PACK_INT(4),?PACK_LIST(5,int32),?PACK_LIST(6,p_activity_completion_new)
>>;
pack_toc(m_activity_completion_point_toc, R) -><<
?ACTIVITY_COMPLETION_POINT:32,?PACK_INT(2),?PACK_INT(3),?PACK_STR(4),?PACK_INT(5)
>>;
pack_toc(m_activity_completion_fetch_toc, R) -><<
?ACTIVITY_COMPLETION_FETCH:32,?PACK_INT(2),?PACK_INT(3),?PACK_STR(4)
>>;
pack_toc(m_activity_recommend_toc, R) -><<
?ACTIVITY_RECOMMEND:32,?PACK_LIST(2,p_activity_completion_new)
>>;
pack_toc(m_activity_benefit_buy_toc, R) -><<
?ACTIVITY_BENEFIT_BUY:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_INT(4)
>>;
pack_toc(m_activity_notice_start_toc, R) -><<
?ACTIVITY_NOTICE_START:32,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5)
>>;
pack_toc(m_activity_notice_end_toc, R) -><<
?ACTIVITY_NOTICE_END:32,?PACK_INT(2)
>>;
pack_toc(m_activity_notice_transfer_toc, R) -><<
?ACTIVITY_NOTICE_TRANSFER:32,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_STR(5)
>>;
pack_toc(m_activity_schedule_info_toc, R) -><<
?ACTIVITY_SCHEDULE_INFO:32,?PACK_INT(2),?PACK_STR(3),?PACK_INT(4),?PACK_TYPE(5,p_activity_rank),?PACK_LIST(6,p_activity_rank),?PACK_INT(7),?PACK_INT(8),?PACK_INT(9),?PACK_INT(10)
>>;
pack_toc(m_activity_schedule_fetch_toc, R) -><<
?ACTIVITY_SCHEDULE_FETCH:32,?PACK_INT(2),?PACK_STR(3),?PACK_INT(4)
>>;
pack_toc(m_activity_drunk_time_toc, R) -><<
?ACTIVITY_DRUNK_TIME:32,?PACK_INT(2),?PACK_INT(3)
>>;
pack_toc(m_activity_daily_pay_reward_toc, R) -><<
?ACTIVITY_DAILY_PAY_REWARD:32,?PACK_BOOL(2),?PACK_INT(3),?PACK_INT(4)
>>;
pack_toc(m_activity_gather_toc, R) -><<
?ACTIVITY_GATHER:32,?PACK_INT(2),?PACK_STR(3)
>>;
pack_toc(m_activity_fecth_toc, R) -><<
?ACTIVITY_FECTH:32,?PACK_INT(2),?PACK_STR(3)
>>;
pack_toc(m_activity_yunying_info_toc, R) -><<
?ACTIVITY_YUNYING_INFO:32,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_STR(5),?PACK_LIST(6,p_activity_reward_info)
>>;
pack_toc(m_activity_exp_back_fetch_toc, R) -><<
?ACTIVITY_EXP_BACK_FETCH:32,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_STR(5)
>>;
pack_toc(m_level_gift_list_toc, R) -><<
?LEVEL_GIFT_LIST:32,?PACK_INT(2)
>>;
pack_toc(m_pet_enter_toc, R) -><<
?PET_ENTER:32,?PACK_LIST(2,p_map_pet)
>>;
pack_toc(m_pet_quit_toc, R) -><<
?PET_QUIT:32,?PACK_INT(2)
>>;
pack_toc(m_pet_attr_change_toc, R) -><<
?PET_ATTR_CHANGE:32,?PACK_INT(2),?PACK_INT(3),?PACK_FLOAT(4)
>>;
pack_toc(m_pet_summon_toc, R) -><<
?PET_SUMMON:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_TYPE(4,p_pet)
>>;
pack_toc(m_pet_call_back_toc, R) -><<
?PET_CALL_BACK:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_INT(4)
>>;
pack_toc(m_pet_info_toc, R) -><<
?PET_INFO:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_TYPE(4,p_pet)
>>;
pack_toc(m_pet_bag_info_toc, R) -><<
?PET_BAG_INFO:32,?PACK_TYPE(2,p_role_pet_bag)
>>;
pack_toc(m_pet_dead_toc, R) -><<
?PET_DEAD:32,?PACK_INT(2)
>>;
pack_toc(m_pet_all_toc, R) -><<
?PET_ALL:32,?PACK_TYPE(2,p_role_pet_bag),?PACK_LIST(3,p_pet)
>>;
pack_toc(m_pet_collect_list_toc, R) -><<
?PET_COLLECT_LIST:32,?PACK_INT(2),?PACK_LIST(3,p_pet_collect)
>>;
pack_toc(m_pet_collect_eat_toc, R) -><<
?PET_COLLECT_EAT:32,?PACK_INT(2),?PACK_TYPE(3,p_pet_collect),?PACK_INT(4),?PACK_STR(5)
>>;
pack_toc(m_pet_collect_change_toc, R) -><<
?PET_COLLECT_CHANGE:32,?PACK_INT(2),?PACK_STR(3)
>>;
pack_toc(m_pet_collect_new_toc, R) -><<
?PET_COLLECT_NEW:32,?PACK_TYPE(2,p_pet_collect)
>>;
pack_toc(m_stat_config_toc, R) -><<
?STAT_CONFIG:32,?PACK_BOOL(2)
>>;
pack_toc(m_present_get_toc, R) -><<
?PRESENT_GET:32,?PACK_INT(2),?PACK_STR(3),?PACK_INT(4),?PACK_TYPE(5,p_present_info)
>>;
pack_toc(m_present_notify_toc, R) -><<
?PRESENT_NOTIFY:32,?PACK_LIST(2,p_present_info)
>>;
pack_toc(m_vip_info_toc, R) -><<
?VIP_INFO:32,?PACK_TYPE(2,p_role_vip)
>>;
pack_toc(m_vip_notice_toc, R) -><<
?VIP_NOTICE:32,?PACK_BOOL(2)
>>;
pack_toc(m_vip_next_info_toc, _R) -><<
?VIP_NEXT_INFO:32>>;
pack_toc(m_vip_remote_depot_toc, R) -><<
?VIP_REMOTE_DEPOT:32,?PACK_BOOL(2),?PACK_STR(3)
>>;
pack_toc(m_vip_stop_notify_toc, R) -><<
?VIP_STOP_NOTIFY:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_INT(4)
>>;
pack_toc(m_vip_reback_gold_toc, R) -><<
?VIP_REBACK_GOLD:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_INT(4)
>>;
pack_toc(m_vip_reward_toc, R) -><<
?VIP_REWARD:32,?PACK_BOOL(2),?PACK_INT(3),?PACK_INT(4)
>>;
pack_toc(m_vip_reward_info_toc, R) -><<
?VIP_REWARD_INFO:32,?PACK_BOOL(2),?PACK_INT(3),?PACK_BOOL(4),?PACK_BOOL(5)
>>;
pack_toc(m_vip_consume_notice_toc, R) -><<
?VIP_CONSUME_NOTICE:32,?PACK_INT(2),?PACK_INT(3)
>>;
pack_toc(m_vip_buy_buff_toc, R) -><<
?VIP_BUY_BUFF:32,?PACK_INT(2),?PACK_INT(3),?PACK_STR(4),?PACK_INT(5),?PACK_INT(6)
>>;
pack_toc(m_vip_gift_toc, R) -><<
?VIP_GIFT:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_INT(4),?PACK_LIST(5,int32)
>>;
pack_toc(m_vip_sell_info_toc, R) -><<
?VIP_SELL_INFO:32,?PACK_INT(2),?PACK_INT(3)
>>;
pack_toc(m_vip_sell_toc, R) -><<
?VIP_SELL:32,?PACK_INT(2),?PACK_INT(3),?PACK_STR(4)
>>;
pack_toc(m_fmlshop_error_toc, R) -><<
?FMLSHOP_ERROR:32,?PACK_INT(2),?PACK_STR(3)
>>;
pack_toc(m_fmlshop_list_toc, R) -><<
?FMLSHOP_LIST:32,?PACK_LIST(2,p_fmlshop_item)
>>;
pack_toc(m_fmlshop_add_toc, R) -><<
?FMLSHOP_ADD:32,?PACK_INT(2)
>>;
pack_toc(m_fmlshop_buy_toc, _R) -><<
?FMLSHOP_BUY:32>>;
pack_toc(m_scene_war_fb_query_toc, R) -><<
?SCENE_WAR_FB_QUERY:32,?PACK_BOOL(2),?PACK_INT(3),?PACK_INT(4),?PACK_STR(5),?PACK_INT(6),?PACK_BOOL(7),?PACK_LIST(8,p_scene_war_fb_link)
>>;
pack_toc(m_scene_war_fb_enter_toc, R) -><<
?SCENE_WAR_FB_ENTER:32,?PACK_BOOL(2),?PACK_BOOL(3),?PACK_STR(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_INT(8),?PACK_INT(9),?PACK_INT(10),?PACK_INT(11),?PACK_INT(12),?PACK_INT(13),?PACK_BOOL(14)
>>;
pack_toc(m_scene_war_fb_end_toc, R) -><<
?SCENE_WAR_FB_END:32,?PACK_INT(2)
>>;
pack_toc(m_family_set_interior_manager_toc, R) -><<
?FAMILY_SET_INTERIOR_MANAGER:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_BOOL(4),?PACK_INT(5),?PACK_STR(6),?PACK_INT(7),?PACK_STR(8)
>>;
pack_toc(m_family_unset_interior_manager_toc, R) -><<
?FAMILY_UNSET_INTERIOR_MANAGER:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_BOOL(4),?PACK_INT(5)
>>;
pack_toc(m_family_leftright_protector_toc, R) -><<
?FAMILY_LEFTRIGHT_PROTECTOR:32,?PACK_INT(2),?PACK_STR(3),?PACK_INT(4),?PACK_STR(5),?PACK_INT(6),?PACK_STR(7)
>>;
pack_toc(m_family_notify_online_toc, R) -><<
?FAMILY_NOTIFY_ONLINE:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_LIST(4,p_family_member_info)
>>;
pack_toc(m_activity_boss_group_toc, R) -><<
?ACTIVITY_BOSS_GROUP:32,?PACK_INT(2),?PACK_STR(3),?PACK_INT(4),?PACK_INT(5),?PACK_LIST(6,p_boss_group)
>>;
pack_toc(m_rankreward_info_toc, R) -><<
?RANKREWARD_INFO:32,?PACK_INT(2),?PACK_BOOL(3),?PACK_BOOL(4),?PACK_TYPE(5,p_jingjie_rank_yesterday),?PACK_INT(6)
>>;
pack_toc(m_rankreward_fetch_reward_toc, R) -><<
?RANKREWARD_FETCH_REWARD:32,?PACK_INT(2),?PACK_INT(3),?PACK_STR(4),?PACK_INT(5)
>>;
pack_toc(m_nationbattle_enter_toc, R) -><<
?NATIONBATTLE_ENTER:32,?PACK_INT(2),?PACK_INT(3),?PACK_STR(4)
>>;
pack_toc(m_nationbattle_quit_toc, R) -><<
?NATIONBATTLE_QUIT:32,?PACK_INT(2),?PACK_STR(3),?PACK_INT(4)
>>;
pack_toc(m_nationbattle_transfer_toc, R) -><<
?NATIONBATTLE_TRANSFER:32,?PACK_INT(2),?PACK_INT(3),?PACK_STR(4)
>>;
pack_toc(m_nationbattle_info_toc, R) -><<
?NATIONBATTLE_INFO:32,?PACK_INT(2),?PACK_LIST(3,int32),?PACK_LIST(4,int32),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_INT(8)
>>;
pack_toc(m_nationbattle_rank_toc, R) -><<
?NATIONBATTLE_RANK:32,?PACK_LIST(2,p_nationbattle_rank)
>>;
pack_toc(m_nationbattle_change_toc, R) -><<
?NATIONBATTLE_CHANGE:32,?PACK_INT(2),?PACK_LIST(3,int32)
>>;
pack_toc(m_nationbattle_reward_toc, R) -><<
?NATIONBATTLE_REWARD:32,?PACK_INT(2),?PACK_STR(3),?PACK_TYPE(4,p_nationbattle_rank),?PACK_INT(5),?PACK_LIST(6,int32),?PACK_INT(7)
>>;
pack_toc(m_nationbattle_fetch_reward_toc, R) -><<
?NATIONBATTLE_FETCH_REWARD:32,?PACK_INT(2),?PACK_STR(3),?PACK_INT(4),?PACK_LIST(5,int32),?PACK_INT(6)
>>;
pack_toc(m_pve_fb_buff_list_toc, R) -><<
?PVE_FB_BUFF_LIST:32,?PACK_LIST(2,p_pve_fb_buff_info)
>>;
pack_toc(m_pve_fb_buy_buff_toc, R) -><<
?PVE_FB_BUY_BUFF:32,?PACK_INT(2),?PACK_INT(3),?PACK_STR(4)
>>;
pack_toc(m_caishen_silver_info_toc, R) -><<
?CAISHEN_SILVER_INFO:32,?PACK_BOOL(2),?PACK_INT(3),?PACK_TYPE(4,p_caishen_coin),?PACK_INT(5),?PACK_INT(6)
>>;
pack_toc(m_caishen_silver_fetch_toc, R) -><<
?CAISHEN_SILVER_FETCH:32,?PACK_BOOL(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_TYPE(8,p_caishen_coin),?PACK_INT(9),?PACK_INT(10)
>>;
pack_toc(m_caishen_firecoin_info_toc, R) -><<
?CAISHEN_FIRECOIN_INFO:32,?PACK_TYPE(2,p_caishen_coin),?PACK_INT(3)
>>;
pack_toc(m_caishen_firecoin_fetch_toc, R) -><<
?CAISHEN_FIRECOIN_FETCH:32,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_TYPE(6,p_caishen_coin),?PACK_INT(7)
>>;
pack_toc(m_caishen_confirm_toc, R) -><<
?CAISHEN_CONFIRM:32,?PACK_INT(2),?PACK_INT(3)
>>;
pack_toc(m_shenqi_eat_toc, _R) -><<
?SHENQI_EAT:32>>;
pack_toc(m_shenqi_transfer_toc, _R) -><<
?SHENQI_TRANSFER:32>>;
pack_toc(m_bigpve_enter_toc, R) -><<
?BIGPVE_ENTER:32,?PACK_INT(2),?PACK_STR(3),?PACK_INT(4)
>>;
pack_toc(m_bigpve_quit_toc, R) -><<
?BIGPVE_QUIT:32,?PACK_INT(2),?PACK_STR(3),?PACK_INT(4)
>>;
pack_toc(m_bigpve_info_toc, R) -><<
?BIGPVE_INFO:32,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7)
>>;
pack_toc(m_bigpve_rank_toc, R) -><<
?BIGPVE_RANK:32,?PACK_LIST(2,p_bigpve_rank),?PACK_FLOAT(3),?PACK_INT(4)
>>;
pack_toc(m_bigpve_buy_buff_toc, R) -><<
?BIGPVE_BUY_BUFF:32,?PACK_INT(2),?PACK_INT(3),?PACK_STR(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7)
>>;
pack_toc(m_bigpve_boss_dead_toc, R) -><<
?BIGPVE_BOSS_DEAD:32,?PACK_STR(2),?PACK_FLOAT(3),?PACK_INT(4),?PACK_FLOAT(5),?PACK_INT(6),?PACK_STR(7),?PACK_FLOAT(8),?PACK_INT(9)
>>;
pack_toc(m_bigpve_result_toc, R) -><<
?BIGPVE_RESULT:32,?PACK_INT(2),?PACK_FLOAT(3),?PACK_INT(4),?PACK_FLOAT(5),?PACK_INT(6),?PACK_INT(7)
>>;
pack_toc(m_bigpve_bomb_toc, R) -><<
?BIGPVE_BOMB:32,?PACK_BOOL(2),?PACK_INT(3),?PACK_FLOAT(4),?PACK_INT(5),?PACK_INT(6)
>>;
pack_toc(m_bigpve_lower_hp_notify_toc, R) -><<
?BIGPVE_LOWER_HP_NOTIFY:32,?PACK_INT(2)
>>;
pack_toc(m_monster_war_info_toc, R) -><<
?MONSTER_WAR_INFO:32,?PACK_INT(2),?PACK_INT(3),?PACK_LIST(4,p_monster_war_rank),?PACK_INT(5)
>>;
pack_toc(m_monster_war_wave_toc, R) -><<
?MONSTER_WAR_WAVE:32,?PACK_INT(2),?PACK_INT(3)
>>;
pack_toc(m_monster_war_history_toc, R) -><<
?MONSTER_WAR_HISTORY:32,?PACK_INT(2),?PACK_INT(3),?PACK_LIST(4,p_monster_war_rank)
>>;
pack_toc(m_rnkm_open_toc, R) -><<
?RNKM_OPEN:32,?PACK_TYPE(2,p_rnkm_role),?PACK_LIST(3,p_rnkm_mirror),?PACK_INT(4),?PACK_INT(5)
>>;
pack_toc(m_rnkm_challenge_toc, R) -><<
?RNKM_CHALLENGE:32,?PACK_INT(2),?PACK_INT(3)
>>;
pack_toc(m_rnkm_update_role_toc, R) -><<
?RNKM_UPDATE_ROLE:32,?PACK_TYPE(2,p_rnkm_role)
>>;
pack_toc(m_rnkm_update_mirror_toc, R) -><<
?RNKM_UPDATE_MIRROR:32,?PACK_TYPE(2,p_rnkm_mirror)
>>;
pack_toc(m_rnkm_add_chance_toc, R) -><<
?RNKM_ADD_CHANCE:32,?PACK_INT(2)
>>;
pack_toc(m_rnkm_error_toc, R) -><<
?RNKM_ERROR:32,?PACK_INT(2),?PACK_STR(3)
>>;
pack_toc(m_rnkm_score_deal_toc, R) -><<
?RNKM_SCORE_DEAL:32,?PACK_INT(2),?PACK_INT(3),?PACK_LIST(4,int32)
>>;
pack_toc(m_rnkm_notify_toc, R) -><<
?RNKM_NOTIFY:32,?PACK_INT(2),?PACK_INT(3),?PACK_STR(4)
>>;
pack_toc(m_rnkm_refresh_toc, R) -><<
?RNKM_REFRESH:32,?PACK_LIST(2,p_rnkm_mirror)
>>;
pack_toc(m_family_welfare_error_toc, R) -><<
?FAMILY_WELFARE_ERROR:32,?PACK_INT(2),?PACK_STR(3)
>>;
pack_toc(m_family_welfare_get_toc, _R) -><<
?FAMILY_WELFARE_GET:32>>;
pack_toc(m_family_idol_error_toc, R) -><<
?FAMILY_IDOL_ERROR:32,?PACK_INT(2),?PACK_STR(3)
>>;
pack_toc(m_family_idol_open_toc, R) -><<
?FAMILY_IDOL_OPEN:32,?PACK_INT(2),?PACK_INT(3),?PACK_LIST(4,p_family_pray_rec)
>>;
pack_toc(m_family_idol_pray_toc, R) -><<
?FAMILY_IDOL_PRAY:32,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_INT(8),?PACK_INT(9)
>>;
pack_toc(m_family_idol_update_toc, R) -><<
?FAMILY_IDOL_UPDATE:32,?PACK_TYPE(2,p_family_pray_rec)
>>;
pack_toc(m_treasbox_show_toc, R) -><<
?TREASBOX_SHOW:32,?PACK_INT(2),?PACK_STR(3),?PACK_INT(4),?PACK_INT(5),?PACK_BOOL(6),?PACK_INT(7),?PACK_LIST(8,p_goods),?PACK_LIST(9,p_goods),?PACK_INT(10),?PACK_INT(11)
>>;
pack_toc(m_treasbox_log_toc, R) -><<
?TREASBOX_LOG:32,?PACK_BOOL(2),?PACK_LIST(3,p_treasbox_log)
>>;
pack_toc(m_treasbox_open_toc, R) -><<
?TREASBOX_OPEN:32,?PACK_INT(2),?PACK_STR(3),?PACK_INT(4),?PACK_INT(5),?PACK_LIST(6,p_goods),?PACK_LIST(7,p_goods),?PACK_TYPE(8,p_reward_prop),?PACK_TYPE(9,p_treasbox_log),?PACK_TYPE(10,p_treasbox_log),?PACK_INT(11),?PACK_INT(12)
>>;
pack_toc(m_treasbox_get_toc, R) -><<
?TREASBOX_GET:32,?PACK_INT(2),?PACK_STR(3),?PACK_LIST(4,p_goods)
>>;
pack_toc(m_treasbox_refresh_toc, R) -><<
?TREASBOX_REFRESH:32,?PACK_INT(2),?PACK_INT(3)
>>;
pack_toc(m_sms_send_toc, R) -><<
?SMS_SEND:32,?PACK_LIST(2,p_sms)
>>;
pack_toc(m_sms_notify_toc, R) -><<
?SMS_NOTIFY:32,?PACK_INT(2),?PACK_STR(3),?PACK_LIST(4,int32)
>>;
pack_toc(m_newcomer_onlinetime_info_toc, R) -><<
?NEWCOMER_ONLINETIME_INFO:32,?PACK_LIST(2,p_reward_prop),?PACK_INT(3)
>>;
pack_toc(m_newcomer_onlinetime_fetch_toc, R) -><<
?NEWCOMER_ONLINETIME_FETCH:32,?PACK_INT(2),?PACK_STR(3),?PACK_LIST(4,p_reward_prop),?PACK_LIST(5,p_reward_prop),?PACK_INT(6)
>>;
pack_toc(m_gift_limited_show_toc, R) -><<
?GIFT_LIMITED_SHOW:32,?PACK_INT(2),?PACK_STR(3),?PACK_LIST(4,int32),?PACK_LIST(5,p_gift_reward)
>>;
pack_toc(m_gift_limited_fetch_toc, R) -><<
?GIFT_LIMITED_FETCH:32,?PACK_INT(2),?PACK_STR(3),?PACK_INT(4)
>>;
pack_toc(m_gift_limited_open_toc, R) -><<
?GIFT_LIMITED_OPEN:32,?PACK_INT(2),?PACK_STR(3)
>>;
pack_toc(m_role_goal_info_toc, R) -><<
?ROLE_GOAL_INFO:32,?PACK_INT(2),?PACK_STR(3),?PACK_LIST(4,p_role_goal),?PACK_BOOL(5)
>>;
pack_toc(m_role_goal_reach_toc, R) -><<
?ROLE_GOAL_REACH:32,?PACK_INT(2),?PACK_STR(3),?PACK_LIST(4,p_role_goal)
>>;
pack_toc(m_role_goal_fetch_toc, R) -><<
?ROLE_GOAL_FETCH:32,?PACK_INT(2),?PACK_STR(3),?PACK_INT(4)
>>;
pack_toc(m_achievement_info_toc, R) -><<
?ACHIEVEMENT_INFO:32,?PACK_LIST(2,p_role_achievement)
>>;
pack_toc(m_achievement_fetch_toc, R) -><<
?ACHIEVEMENT_FETCH:32,?PACK_TYPE(2,p_role_achievement)
>>;
pack_toc(m_achievement_update_toc, R) -><<
?ACHIEVEMENT_UPDATE:32,?PACK_TYPE(2,p_role_achievement)
>>;
pack_toc(m_fund_info_toc, R) -><<
?FUND_INFO:32,?PACK_LIST(2,p_role_fund)
>>;
pack_toc(m_fund_active_toc, R) -><<
?FUND_ACTIVE:32,?PACK_TYPE(2,p_role_fund),?PACK_INT(3)
>>;
pack_toc(m_fund_fetch_toc, R) -><<
?FUND_FETCH:32,?PACK_TYPE(2,p_role_fund)
>>;
pack_toc(m_fund_level_buy_toc, _R) -><<
?FUND_LEVEL_BUY:32>>;
pack_toc(m_fund_level_info_toc, R) -><<
?FUND_LEVEL_INFO:32,?PACK_BOOL(2),?PACK_INT(3)
>>;
pack_toc(m_fund_level_fetch_toc, _R) -><<
?FUND_LEVEL_FETCH:32>>;
pack_toc(m_login_reward_info_toc, R) -><<
?LOGIN_REWARD_INFO:32,?PACK_BOOL(2),?PACK_INT(3),?PACK_LIST(4,int32),?PACK_LIST(5,p_reward_prop)
>>;
pack_toc(m_login_reward_fetch_toc, _R) -><<
?LOGIN_REWARD_FETCH:32>>;
pack_toc(m_tower_fb_enter_toc, R) -><<
?TOWER_FB_ENTER:32,?PACK_BOOL(2),?PACK_INT(3),?PACK_STR(4),?PACK_INT(5),?PACK_INT(6),?PACK_LIST(7,p_reward_prop),?PACK_LIST(8,p_reward_prop)
>>;
pack_toc(m_tower_fb_quit_toc, _R) -><<
?TOWER_FB_QUIT:32>>;
pack_toc(m_tower_fb_info_toc, R) -><<
?TOWER_FB_INFO:32,?PACK_BOOL(2),?PACK_INT(3),?PACK_STR(4),?PACK_INT(5),?PACK_INT(6),?PACK_LIST(7,p_reward_prop),?PACK_INT(8),?PACK_INT(9)
>>;
pack_toc(m_tower_fb_reward_toc, R) -><<
?TOWER_FB_REWARD:32,?PACK_BOOL(2),?PACK_INT(3),?PACK_STR(4)
>>;
pack_toc(m_tower_fb_result_toc, R) -><<
?TOWER_FB_RESULT:32,?PACK_INT(2)
>>;
pack_toc(m_best_tower_fb_info_toc, R) -><<
?BEST_TOWER_FB_INFO:32,?PACK_FLOAT(2),?PACK_STR(3),?PACK_INT(4)
>>;
pack_toc(m_tower_fb_status_toc, R) -><<
?TOWER_FB_STATUS:32,?PACK_INT(2)
>>;
pack_toc(m_time_activity_info_toc, R) -><<
?TIME_ACTIVITY_INFO:32,?PACK_LIST(2,p_time_activity),?PACK_LIST(3,p_org_activity)
>>;
pack_toc(m_time_activity_fetch_toc, R) -><<
?TIME_ACTIVITY_FETCH:32,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4)
>>;
pack_toc(m_time_activity_org_fetch_toc, R) -><<
?TIME_ACTIVITY_ORG_FETCH:32,?PACK_INT(2)
>>;
pack_toc(m_time_activity_update_toc, R) -><<
?TIME_ACTIVITY_UPDATE:32,?PACK_LIST(2,p_time_activity)
>>;
pack_toc(m_version_notice_toc, R) -><<
?VERSION_NOTICE:32,?PACK_STR(2)
>>;
pack_toc(m_room_create_toc, R) -><<
?ROOM_CREATE:32,?PACK_TYPE(2,p_room_info)
>>;
pack_toc(m_room_self_toc, R) -><<
?ROOM_SELF:32,?PACK_BOOL(2),?PACK_TYPE(3,p_room_info)
>>;
pack_toc(m_room_list_toc, R) -><<
?ROOM_LIST:32,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_LIST(5,p_room_info)
>>;
pack_toc(m_room_join_toc, R) -><<
?ROOM_JOIN:32,?PACK_TYPE(2,p_room_info)
>>;
pack_toc(m_room_kick_toc, R) -><<
?ROOM_KICK:32,?PACK_INT(2),?PACK_INT(3)
>>;
pack_toc(m_common_fb_enter_times_toc, R) -><<
?COMMON_FB_ENTER_TIMES:32,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4)
>>;
pack_toc(m_common_fb_lost_monster_toc, R) -><<
?COMMON_FB_LOST_MONSTER:32,?PACK_INT(2),?PACK_INT(3)
>>;
pack_toc(m_common_fb_lianzhan_toc, R) -><<
?COMMON_FB_LIANZHAN:32,?PACK_INT(2),?PACK_INT(3)
>>;
pack_toc(m_common_fb_collect_box_toc, R) -><<
?COMMON_FB_COLLECT_BOX:32,?PACK_INT(2),?PACK_INT(3)
>>;
pack_toc(m_common_fb_kill_report_toc, R) -><<
?COMMON_FB_KILL_REPORT:32,?PACK_INT(2),?PACK_INT(3)
>>;
pack_toc(m_common_fb_mirrors_toc, R) -><<
?COMMON_FB_MIRRORS:32,?PACK_INT(2),?PACK_LIST(3,p_team_mirror_info)
>>;
pack_toc(m_compare_sell_info_toc, R) -><<
?COMPARE_SELL_INFO:32,?PACK_LIST(2,p_compare_info)
>>;
pack_toc(m_compare_sell_fetch_toc, R) -><<
?COMPARE_SELL_FETCH:32,?PACK_BOOL(2),?PACK_INT(3),?PACK_INT(4),?PACK_STR(5)
>>;
pack_toc(m_team_mirror_info_toc, R) -><<
?TEAM_MIRROR_INFO:32,?PACK_INT(2),?PACK_INT(3)
>>;
pack_toc(m_team_mirror_enter_toc, R) -><<
?TEAM_MIRROR_ENTER:32,?PACK_INT(2),?PACK_STR(3),?PACK_INT(4)
>>;
pack_toc(m_team_mirror_quit_toc, R) -><<
?TEAM_MIRROR_QUIT:32,?PACK_BOOL(2),?PACK_STR(3)
>>;
pack_toc(m_team_mirror_report_toc, R) -><<
?TEAM_MIRROR_REPORT:32,?PACK_INT(2),?PACK_INT(3),?PACK_LIST(4,p_prop),?PACK_INT(5),?PACK_INT(6),?PACK_LIST(7,int32)
>>;
pack_toc(m_team_mirror_get_friends_toc, R) -><<
?TEAM_MIRROR_GET_FRIENDS:32,?PACK_INT(2),?PACK_LIST(3,p_team_mirror_info)
>>;
pack_toc(m_family_war_score_toc, R) -><<
?FAMILY_WAR_SCORE:32,?PACK_INT(2),?PACK_LIST(3,p_family_war_score)
>>;
pack_toc(m_family_war_my_buffs_toc, R) -><<
?FAMILY_WAR_MY_BUFFS:32,?PACK_LIST(2,int32)
>>;
pack_toc(m_family_war_commit_medicine_toc, R) -><<
?FAMILY_WAR_COMMIT_MEDICINE:32,?PACK_BOOL(2),?PACK_INT(3)
>>;
pack_toc(m_super_mission_info_toc, R) -><<
?SUPER_MISSION_INFO:32,?PACK_INT(2),?PACK_INT(3),?PACK_LIST(4,p_super_task),?PACK_INT(5)
>>;
pack_toc(m_super_mission_opt_toc, R) -><<
?SUPER_MISSION_OPT:32,?PACK_BOOL(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6)
>>;
pack_toc(m_activity_open_activity_status_toc, R) -><<
?ACTIVITY_OPEN_ACTIVITY_STATUS:32,?PACK_BOOL(2),?PACK_LIST(3,p_open_activity)
>>;
pack_toc(m_activity_open_activity_info_toc, R) -><<
?ACTIVITY_OPEN_ACTIVITY_INFO:32,?PACK_INT(2),?PACK_STR(3),?PACK_INT(4),?PACK_INT(5),?PACK_FLOAT(6),?PACK_LIST(7,p_open_activity_rank)
>>;
pack_toc(m_activity_open_activity_rank_toc, R) -><<
?ACTIVITY_OPEN_ACTIVITY_RANK:32,?PACK_INT(2),?PACK_STR(3),?PACK_INT(4),?PACK_LIST(5,p_open_activity_rank)
>>;
pack_toc(m_daily_activity_info_toc, R) -><<
?DAILY_ACTIVITY_INFO:32,?PACK_INT(2),?PACK_STR(3),?PACK_LIST(4,p_daily_activity)
>>;
pack_toc(m_daily_activity_counter_toc, R) -><<
?DAILY_ACTIVITY_COUNTER:32,?PACK_INT(2),?PACK_INT(3)
>>;
pack_toc(m_daily_activity_guide_toc, R) -><<
?DAILY_ACTIVITY_GUIDE:32,?PACK_LIST(2,p_daily_activity_guide)
>>;
pack_toc(m_daily_activity_forecast_toc, R) -><<
?DAILY_ACTIVITY_FORECAST:32,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4)
>>;
pack_toc(m_cd_info_toc, R) -><<
?CD_INFO:32,?PACK_INT(2),?PACK_INT(3)
>>;
pack_toc(m_cd_clear_toc, R) -><<
?CD_CLEAR:32,?PACK_INT(2)
>>;
pack_toc(m_cd_free_hunt_toc, R) -><<
?CD_FREE_HUNT:32,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4)
>>;
pack_toc(m_cd_free_notice_toc, R) -><<
?CD_FREE_NOTICE:32,?PACK_INT(2)
>>;
pack_toc(m_daily_benefit_info_toc, R) -><<
?DAILY_BENEFIT_INFO:32,?PACK_INT(2),?PACK_STR(3),?PACK_LIST(4,p_daily_benefit_info),?PACK_TYPE(5,p_daily_benefit_expback),?PACK_TYPE(6,p_daily_benefit_expback)
>>;
pack_toc(m_daily_benefit_fetch_toc, R) -><<
?DAILY_BENEFIT_FETCH:32,?PACK_INT(2),?PACK_INT(3),?PACK_STR(4)
>>;
pack_toc(m_map_update_hp_toc, R) -><<
?MAP_UPDATE_HP:32,?PACK_INT(2),?PACK_INT(3),?PACK_FLOAT(4)
>>;
pack_toc(m_shop_shops_toc, R) -><<
?SHOP_SHOPS:32,?PACK_LIST(2,p_shop_info)
>>;
pack_toc(m_shop_all_goods_toc, R) -><<
?SHOP_ALL_GOODS:32,?PACK_INT(2),?PACK_LIST(3,p_shop_goods_info),?PACK_INT(4),?PACK_INT(5)
>>;
pack_toc(m_shop_item_toc, R) -><<
?SHOP_ITEM:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_INT(4),?PACK_TYPE(5,p_shop_goods_info)
>>;
pack_toc(m_shop_search_toc, R) -><<
?SHOP_SEARCH:32,?PACK_LIST(2,p_shop_goods_info),?PACK_INT(3)
>>;
pack_toc(m_shop_buy_toc, R) -><<
?SHOP_BUY:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_INT(4),?PACK_INT(5)
>>;
pack_toc(m_shop_sale_toc, R) -><<
?SHOP_SALE:32,?PACK_BOOL(2),?PACK_LIST(3,int32),?PACK_LIST(4,int32),?PACK_STR(5)
>>;
pack_toc(m_shop_buy_back_toc, R) -><<
?SHOP_BUY_BACK:32,?PACK_INT(2),?PACK_LIST(3,p_goods),?PACK_BOOL(4),?PACK_STR(5),?PACK_INT(6)
>>;
pack_toc(m_shop_npc_toc, R) -><<
?SHOP_NPC:32,?PACK_INT(2),?PACK_LIST(3,p_shop_info)
>>;
pack_toc(m_lotto_info_toc, R) -><<
?LOTTO_INFO:32,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6),?PACK_LIST(7,p_prop)
>>;
pack_toc(m_lotto_play_toc, R) -><<
?LOTTO_PLAY:32,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_TYPE(6,p_prop),?PACK_INT(7)
>>;
pack_toc(m_lotto_history_toc, R) -><<
?LOTTO_HISTORY:32,?PACK_LIST(2,p_lotto_his)
>>;
pack_toc(m_danyao_info_toc, R) -><<
?DANYAO_INFO:32,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_LIST(6,p_danyao_hole)
>>;
pack_toc(m_danyao_eat_toc, R) -><<
?DANYAO_EAT:32,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_LIST(6,p_danyao_hole)
>>;
pack_toc(m_signin_operate_toc, R) -><<
?SIGNIN_OPERATE:32,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_BOOL(5),?PACK_LIST(6,p_reward_prop),?PACK_BOOL(7)
>>;
pack_toc(m_role2_energy_toc, R) -><<
?ROLE2_ENERGY:32,?PACK_INT(2),?PACK_INT(3)
>>;
pack_toc(m_role2_dazen_info_toc, R) -><<
?ROLE2_DAZEN_INFO:32,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5)
>>;
pack_toc(m_role2_dazen_fetch_toc, R) -><<
?ROLE2_DAZEN_FETCH:32,?PACK_INT(2),?PACK_INT(3)
>>;
pack_toc(m_role2_operate_count_toc, R) -><<
?ROLE2_OPERATE_COUNT:32,?PACK_INT(2),?PACK_INT(3)
>>;
pack_toc(m_payment_info_toc, R) -><<
?PAYMENT_INFO:32,?PACK_BOOL(2),?PACK_BOOL(3),?PACK_LIST(4,int32),?PACK_INT(5)
>>;
pack_toc(m_payment_fetch_toc, R) -><<
?PAYMENT_FETCH:32,?PACK_INT(2),?PACK_BOOL(3)
>>;
pack_toc(m_payment_request_toc, R) -><<
?PAYMENT_REQUEST:32,?PACK_INT(2),?PACK_STR(3),?PACK_STR(4),?PACK_LIST(5,string)
>>;
pack_toc(m_round_pvp_history_toc, R) -><<
?ROUND_PVP_HISTORY:32,?PACK_LIST(2,p_round_pvp_history)
>>;
pack_toc(m_round_pvp_info_toc, R) -><<
?ROUND_PVP_INFO:32,?PACK_LIST(2,p_round_pvp_rank),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_LIST(8,p_reward_prop),?PACK_TYPE(9,p_reward_prop),?PACK_INT(10),?PACK_INT(11)
>>;
pack_toc(m_round_pvp_reward_toc, _R) -><<
?ROUND_PVP_REWARD:32>>;
pack_toc(m_round_pvp_fb_state_toc, R) -><<
?ROUND_PVP_FB_STATE:32,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4)
>>;
pack_toc(m_round_pvp_fb_result_toc, R) -><<
?ROUND_PVP_FB_RESULT:32,?PACK_INT(2)
>>;
pack_toc(m_round_pvp_hall_info_toc, R) -><<
?ROUND_PVP_HALL_INFO:32,?PACK_INT(2),?PACK_INT(3),?PACK_BOOL(4)
>>;
pack_toc(m_gengu_info_toc, R) -><<
?GENGU_INFO:32,?PACK_TYPE(2,p_gengu_info)
>>;
pack_toc(m_gengu_upgrade_toc, R) -><<
?GENGU_UPGRADE:32,?PACK_INT(2),?PACK_BOOL(3),?PACK_STR(4),?PACK_TYPE(5,p_gengu_info)
>>;
pack_toc(m_gengu_autoupgrade_toc, R) -><<
?GENGU_AUTOUPGRADE:32,?PACK_INT(2),?PACK_STR(3),?PACK_TYPE(4,p_gengu_info),?PACK_INT(5),?PACK_INT(6)
>>;
pack_toc(m_qq_info_toc, R) -><<
?QQ_INFO:32,?PACK_INT(2)
>>;
pack_toc(m_qq_buy_gold_toc, R) -><<
?QQ_BUY_GOLD:32,?PACK_INT(2),?PACK_STR(3)
>>;
pack_toc(m_holiday_act_info_toc, R) -><<
?HOLIDAY_ACT_INFO:32,?PACK_BOOL(2),?PACK_INT(3)
>>;
pack_toc(m_holiday_act_gold_history_toc, R) -><<
?HOLIDAY_ACT_GOLD_HISTORY:32,?PACK_LIST(2,p_holiday_gold_act_history)
>>;
pack_toc(m_equip_build_info_toc, R) -><<
?EQUIP_BUILD_INFO:32,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_TYPE(5,p_goods),?PACK_INT(6)
>>;
pack_toc(m_equip_rebuild_toc, R) -><<
?EQUIP_REBUILD:32,?PACK_INT(2),?PACK_INT(3),?PACK_LIST(4,p_k_v),?PACK_INT(5),?PACK_INT(6)
>>;
pack_toc(m_equip_build_refresh_toc, R) -><<
?EQUIP_BUILD_REFRESH:32,?PACK_TYPE(2,p_goods)
>>;
pack_toc(m_equip_build_toc, R) -><<
?EQUIP_BUILD:32,?PACK_INT(2),?PACK_INT(3)
>>;
pack_toc(m_equip_build_list_toc, R) -><<
?EQUIP_BUILD_LIST:32,?PACK_LIST(2,p_shenqi_build)
>>;
pack_toc(m_hanging_offline_toc, R) -><<
?HANGING_OFFLINE:32,?PACK_TYPE(2,p_hanging_offline_report)
>>;
pack_toc(m_hanging_stat_toc, R) -><<
?HANGING_STAT:32,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7)
>>;
pack_toc(m_hanging_change_toc, R) -><<
?HANGING_CHANGE:32,?PACK_TYPE(2,p_battle)
>>;
pack_toc(m_hanging_ready_toc, R) -><<
?HANGING_READY:32,?PACK_TYPE(2,p_battle),?PACK_INT(3),?PACK_LIST(4,p_fighter),?PACK_LIST(5,p_fighter),?PACK_INT(6),?PACK_BOOL(7)
>>;
pack_toc(m_hanging_round_start_toc, R) -><<
?HANGING_ROUND_START:32,?PACK_TYPE(2,p_hanging_round),?PACK_LIST(3,int32),?PACK_BOOL(4),?PACK_INT(5)
>>;
pack_toc(m_hanging_round_end_toc, R) -><<
?HANGING_ROUND_END:32,?PACK_INT(2),?PACK_INT(3)
>>;
pack_toc(m_hanging_continue_toc, R) -><<
?HANGING_CONTINUE:32,?PACK_TYPE(2,p_battle),?PACK_INT(3)
>>;
pack_toc(m_hanging_fb_result_toc, R) -><<
?HANGING_FB_RESULT:32,?PACK_INT(2),?PACK_INT(3),?PACK_BOOL(4),?PACK_INT(5),?PACK_INT(6),?PACK_LIST(7,p_prop)
>>;
pack_toc(m_hanging_buff_toc, R) -><<
?HANGING_BUFF:32,?PACK_TYPE(2,p_hanging_buff)
>>;
pack_toc(m_equip_foster_refresh_toc, R) -><<
?EQUIP_FOSTER_REFRESH:32,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_LIST(5,p_attr)
>>;
pack_toc(m_equip_foster_save_toc, _R) -><<
?EQUIP_FOSTER_SAVE:32>>;
pack_toc(m_equip_foster_transfer_toc, _R) -><<
?EQUIP_FOSTER_TRANSFER:32>>;
pack_toc(m_stone_opt_toc, R) -><<
?STONE_OPT:32,?PACK_INT(2),?PACK_INT(3),?PACK_TYPE(4,p_goods),?PACK_INT(5),?PACK_STR(6)
>>;
pack_toc(m_stone_eat_toc, R) -><<
?STONE_EAT:32,?PACK_INT(2),?PACK_TYPE(3,p_goods),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6),?PACK_STR(7)
>>;
pack_toc(m_main_fb_info_toc, R) -><<
?MAIN_FB_INFO:32,?PACK_TYPE(2,p_main_fb_info)
>>;
pack_toc(m_main_fb_select_toc, R) -><<
?MAIN_FB_SELECT:32,?PACK_INT(2),?PACK_STR(3),?PACK_INT(4),?PACK_INT(5)
>>;
pack_toc(m_main_fb_sweep_toc, R) -><<
?MAIN_FB_SWEEP:32,?PACK_INT(2),?PACK_STR(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6),?PACK_INT(7),?PACK_LIST(8,p_reward_prop),?PACK_LIST(9,p_reward_color),?PACK_LIST(10,p_reward_color)
>>;
pack_toc(m_main_fb_buy_toc, R) -><<
?MAIN_FB_BUY:32,?PACK_INT(2),?PACK_STR(3),?PACK_INT(4),?PACK_INT(5)
>>;
pack_toc(m_main_fb_quick_toc, R) -><<
?MAIN_FB_QUICK:32,?PACK_INT(2),?PACK_STR(3),?PACK_TYPE(4,p_hanging_offline_report)
>>;
pack_toc(m_main_fb_pass_boss_toc, R) -><<
?MAIN_FB_PASS_BOSS:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_BOOL(4),?PACK_INT(5),?PACK_INT(6),?PACK_LIST(7,p_reward_prop)
>>;
pack_toc(m_fmlmatch_info_toc, R) -><<
?FMLMATCH_INFO:32,?PACK_LIST(2,p_fmlmatch_family_rank),?PACK_LIST(3,p_fmlmatch_role_rank),?PACK_TYPE(4,p_fmlmatch_family_rank),?PACK_TYPE(5,p_fmlmatch_role_rank),?PACK_INT(6),?PACK_INT(7),?PACK_INT(8),?PACK_INT(9),?PACK_INT(10),?PACK_TYPE(11,p_fmlmatch_fight),?PACK_LIST(12,p_fmlmatch_fight),?PACK_INT(13),?PACK_INT(14),?PACK_BOOL(15),?PACK_INT(16)
>>;
pack_toc(m_fmlmatch_view_fighting_toc, R) -><<
?FMLMATCH_VIEW_FIGHTING:32,?PACK_TYPE(2,p_hanging_round)
>>;
pack_toc(m_fmlmatch_start_toc, R) -><<
?FMLMATCH_START:32,?PACK_INT(2)
>>;
pack_toc(m_fmlmatch_end_toc, R) -><<
?FMLMATCH_END:32,?PACK_STR(2),?PACK_STR(3)
>>;
pack_toc(m_equip_share_info_toc, R) -><<
?EQUIP_SHARE_INFO:32,?PACK_TYPE(2,p_role_snapshot),?PACK_INT(3),?PACK_LIST(4,p_role_snapshot),?PACK_BOOL(5),?PACK_TYPE(6,p_goods)
>>;
pack_toc(m_equip_share_equips_toc, R) -><<
?EQUIP_SHARE_EQUIPS:32,?PACK_LIST(2,p_goods)
>>;
pack_toc(m_equip_share_list_toc, R) -><<
?EQUIP_SHARE_LIST:32,?PACK_LIST(2,p_role_snapshot)
>>;
pack_toc(m_equip_share_sync_toc, _R) -><<
?EQUIP_SHARE_SYNC:32>>;
pack_toc(m_equip_share_request_toc, R) -><<
?EQUIP_SHARE_REQUEST:32,?PACK_INT(2)
>>;
pack_toc(m_equip_share_requester_add_toc, R) -><<
?EQUIP_SHARE_REQUESTER_ADD:32,?PACK_TYPE(2,p_role_snapshot)
>>;
pack_toc(m_equip_share_agree_toc, R) -><<
?EQUIP_SHARE_AGREE:32,?PACK_INT(2),?PACK_STR(3),?PACK_INT(4),?PACK_STR(5)
>>;
pack_toc(m_equip_share_remove_toc, _R) -><<
?EQUIP_SHARE_REMOVE:32>>;
pack_toc(m_equip_share_requester_del_toc, R) -><<
?EQUIP_SHARE_REQUESTER_DEL:32,?PACK_INT(2)
>>;
pack_toc(m_role2_notice_toc, R) -><<
?ROLE2_NOTICE:32,?PACK_INT(2),?PACK_INT(3)
>>;
pack_toc(m_role2_jingmai_toc, R) -><<
?ROLE2_JINGMAI:32,?PACK_INT(2),?PACK_INT(3),?PACK_LIST(4,int32),?PACK_INT(5),?PACK_STR(6)
>>;
pack_toc(m_single_fb_info_toc, R) -><<
?SINGLE_FB_INFO:32,?PACK_LIST(2,p_single_fb)
>>;
pack_toc(m_single_fb_fight_toc, R) -><<
?SINGLE_FB_FIGHT:32,?PACK_INT(2)
>>;
pack_toc(m_family_fb_info_toc, R) -><<
?FAMILY_FB_INFO:32,?PACK_INT(2),?PACK_LIST(3,int32),?PACK_TYPE(4,p_family_fb_rank)
>>;
pack_toc(m_family_fb_fight_toc, _R) -><<
?FAMILY_FB_FIGHT:32>>;
pack_toc(m_family_fb_result_toc, R) -><<
?FAMILY_FB_RESULT:32,?PACK_INT(2),?PACK_BOOL(3),?PACK_LIST(4,p_prop)
>>;
pack_toc(m_download_task_info_toc, R) -><<
?DOWNLOAD_TASK_INFO:32,?PACK_LIST(2,int32)
>>;
pack_toc(m_download_task_fetch_toc, R) -><<
?DOWNLOAD_TASK_FETCH:32,?PACK_INT(2)
>>;
pack_toc(m_grab_open_toc, R) -><<
?GRAB_OPEN:32,?PACK_TYPE(2,p_grab_role),?PACK_LIST(3,p_rnkm_mirror),?PACK_INT(4)
>>;
pack_toc(m_grab_challenge_toc, R) -><<
?GRAB_CHALLENGE:32,?PACK_INT(2)
>>;
pack_toc(m_grab_fast_fight_toc, R) -><<
?GRAB_FAST_FIGHT:32,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_TYPE(5,p_prop),?PACK_INT(6),?PACK_INT(7),?PACK_LIST(8,p_prop)
>>;
pack_toc(m_grab_refresh_toc, R) -><<
?GRAB_REFRESH:32,?PACK_LIST(2,p_rnkm_mirror)
>>;
pack_toc(m_grab_result_toc, R) -><<
?GRAB_RESULT:32,?PACK_INT(2),?PACK_BOOL(3),?PACK_INT(4),?PACK_INT(5),?PACK_TYPE(6,p_prop),?PACK_TYPE(7,p_prop),?PACK_BOOL(8)
>>;
pack_toc(m_grab_select_reward_toc, R) -><<
?GRAB_SELECT_REWARD:32,?PACK_INT(2),?PACK_LIST(3,p_prop)
>>;
pack_toc(m_grab_add_protect_toc, R) -><<
?GRAB_ADD_PROTECT:32,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4)
>>;
pack_toc(m_grab_update_role_toc, R) -><<
?GRAB_UPDATE_ROLE:32,?PACK_TYPE(2,p_grab_role)
>>;
pack_toc(m_guide_info_toc, R) -><<
?GUIDE_INFO:32,?PACK_INT(2),?PACK_INT(3),?PACK_BOOL(4)
>>;
pack_toc(m_mission_listener_toc, R) -><<
?MISSION_LISTENER:32,?PACK_INT(2),?PACK_LIST(3,int32),?PACK_INT(4),?PACK_TYPE(5,p_mission_listener)
>>;
pack_toc(m_mission_list_toc, R) -><<
?MISSION_LIST:32,?PACK_INT(2),?PACK_LIST(3,int32),?PACK_LIST(4,p_mission_info)
>>;
pack_toc(m_mission_do_toc, R) -><<
?MISSION_DO:32,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_LIST(6,int32),?PACK_INT(7),?PACK_INT(8)
>>;
pack_toc(m_mission_cancel_toc, R) -><<
?MISSION_CANCEL:32,?PACK_INT(2),?PACK_INT(3),?PACK_INT(4),?PACK_INT(5),?PACK_INT(6),?PACK_LIST(7,int32)
>>;
pack_toc(m_mission_update_toc, R) -><<
?MISSION_UPDATE:32,?PACK_LIST(2,int32),?PACK_LIST(3,p_mission_info)
>>;
pack_toc(m_mission_list_auto_toc, R) -><<
?MISSION_LIST_AUTO:32,?PACK_LIST(2,p_mission_auto)
>>;
pack_toc(m_mission_do_auto_toc, R) -><<
?MISSION_DO_AUTO:32,?PACK_INT(2),?PACK_TYPE(3,p_mission_auto),?PACK_INT(4),?PACK_LIST(5,int32)
>>;
pack_toc(m_mission_cancel_auto_toc, R) -><<
?MISSION_CANCEL_AUTO:32,?PACK_INT(2),?PACK_INT(3),?PACK_LIST(4,int32)
>>;
pack_toc(m_mission_touch_set_toc, R) -><<
?MISSION_TOUCH_SET:32,?PACK_INT(2),?PACK_INT(3),?PACK_LIST(4,int32)
>>;
pack_toc(m_mission_show_prop_toc, R) -><<
?MISSION_SHOW_PROP:32,?PACK_INT(2),?PACK_INT(3),?PACK_LIST(4,int32),?PACK_TYPE(5,p_goods)
>>;
pack_toc(m_mission_star_toc, R) -><<
?MISSION_STAR:32,?PACK_INT(2),?PACK_INT(3)
>>;
pack_toc(m_chat_auth_toc, R) -><<
?CHAT_AUTH:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_LIST(4,p_channel_info),?PACK_LIST(5,p_chat_role),?PACK_LIST(6,string)
>>;
pack_toc(m_chat_join_channel_toc, R) -><<
?CHAT_JOIN_CHANNEL:32,?PACK_TYPE(2,p_channel_info),?PACK_TYPE(3,p_chat_role)
>>;
pack_toc(m_chat_leave_channel_toc, R) -><<
?CHAT_LEAVE_CHANNEL:32,?PACK_STR(2),?PACK_INT(3)
>>;
pack_toc(m_chat_in_channel_toc, R) -><<
?CHAT_IN_CHANNEL:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_STR(4),?PACK_STR(5),?PACK_TYPE(6,p_chat_role),?PACK_INT(7)
>>;
pack_toc(m_chat_in_pairs_toc, R) -><<
?CHAT_IN_PAIRS:32,?PACK_BOOL(2),?PACK_INT(3),?PACK_STR(4),?PACK_STR(5),?PACK_TYPE(6,p_chat_role),?PACK_TYPE(7,p_chat_role),?PACK_INT(8),?PACK_INT(9),?PACK_INT(10)
>>;
pack_toc(m_chat_add_black_toc, R) -><<
?CHAT_ADD_BLACK:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_TYPE(4,p_chat_role)
>>;
pack_toc(m_chat_remove_black_toc, R) -><<
?CHAT_REMOVE_BLACK:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_TYPE(4,p_chat_role)
>>;
pack_toc(m_chat_status_change_toc, R) -><<
?CHAT_STATUS_CHANGE:32,?PACK_INT(2),?PACK_STR(3),?PACK_INT(4),?PACK_INT(5)
>>;
pack_toc(m_chat_get_roles_toc, R) -><<
?CHAT_GET_ROLES:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_STR(4),?PACK_INT(5),?PACK_LIST(6,p_chat_channel_role_info)
>>;
pack_toc(m_chat_get_goods_toc, R) -><<
?CHAT_GET_GOODS:32,?PACK_BOOL(2),?PACK_INT(3),?PACK_TYPE(4,p_goods),?PACK_STR(5)
>>;
pack_toc(m_chat_king_ban_toc, R) -><<
?CHAT_KING_BAN:32,?PACK_BOOL(2),?PACK_STR(3),?PACK_INT(4)
>>;
pack_toc(m_chat_postchat_toc, R) -><<
?CHAT_POSTCHAT:32,?PACK_STR(2),?PACK_INT(3),?PACK_STR(4)
>>;
pack_toc(_, _) -> <<>>.


pack_string(Data) -> 
    Binary = if
                 Data =:= undefined -> <<>> ;
                 is_list(Data)      -> list_to_binary(Data);
                 is_integer(Data)   -> list_to_binary(integer_to_list(Data));
                 is_atom(Data)      -> atom_to_binary(Data,latin1);
                 is_tuple(Data)     -> list_to_binary(tuple_to_list(Data));
                 is_bitstring(Data) -> list_to_binary(bitstring_to_list(Data));
                 true               -> Data
             end,
    <<(size(Binary)):16,Binary/binary>>.

pack_list(Type, List) ->
    lists:foldl(fun 
                   (Data, Acc) ->
                        case Type of 
                            bool ->
                                <<Acc/binary,(if(Data) -> 1; true -> 0 end):8/integer-signed>>;
                            int32 ->
                                <<Acc/binary,Data:32/integer-signed>>;
                            double ->
                                <<Acc/binary,Data:64/big-float>>;
                            _ ->
                                <<Acc/binary,(pack(Type, Data))/binary>>
                        end
                end, <<>>, List).    