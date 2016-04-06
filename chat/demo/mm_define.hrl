-define(ROLE, 4).
-define(ROLE_AUTH, 401).
-define(ROLE_ADD, 402).
-define(ROLE_GEN_NAME, 403).
-define(ROLE_CHOOSE, 404).
-define(CHAT, 9).
-define(CHAT_AUTH, 901).
-define(CHAT_IN_CHANNEL, 902).
-define(CHAT_IN_PAIRS, 903).
-define(CHAT_LEAVE_CHANNEL, 904).
-define(CHAT_JOIN_CHANNEL, 908).
-define(CHAT_ADD_BLACK, 909).
-define(CHAT_REMOVE_BLACK, 910).
-define(CHAT_STATUS_CHANGE, 915).
-define(CHAT_GET_ROLES, 916).
-define(CHAT_GET_GOODS, 918).
-define(CHAT_KING_BAN, 920).
-define(CHAT_POSTCHAT, 921).
-define(ROLE2, 5).
-define(ROLE2_ATTR_CHANGE, 501).
-define(ROLE2_LEVELUP, 502).
-define(ROLE2_LEVELUP_OTHER, 503).
-define(ROLE2_DEAD, 505).
-define(ROLE2_DEAD_OTHER, 506).
-define(ROLE2_RELIVE, 507).
-define(ROLE2_ATTR_RELOAD, 508).
-define(ROLE2_GETROLEATTR, 510).
-define(ROLE2_PKMODEMODIFY, 515).
-define(ROLE2_HPMP_CHANGE, 516).
-define(ROLE2_BASE_RELOAD, 519).
-define(ROLE2_UNBUND_CHANGE, 523).
-define(ROLE2_SEX, 527).
-define(ROLE2_SHOW_EQUIP_RING, 533).
-define(ROLE2_REMOVE_SKIN_BUFF, 535).
-define(ROLE2_ONLINE_BROADCAST, 537).
-define(ROLE2_RENAME, 544).
-define(ROLE2_BUY_TILI, 548).
-define(ROLE2_TILI_INFO, 549).
-define(ROLE2_DAILY_PRESENT, 550).
-define(ROLE2_ENERGY, 562).
-define(ROLE2_DAZEN_INFO, 563).
-define(ROLE2_DAZEN_FETCH, 564).
-define(ROLE2_OPERATE_COUNT, 565).
-define(ROLE2_NOTICE, 566).
-define(ROLE2_JINGMAI, 567).
-define(MAP, 3).
-define(MAP_ENTER, 301).
-define(MAP_QUIT, 302).
-define(MAP_DROPTHING_PICK, 305).
-define(MAP_UPDATE_ACTOR_MAPINFO, 306).
-define(MAP_CHANGE_MAP, 307).
-define(MAP_CHANGE_POS, 308).
-define(MAP_SLICE_ENTER, 309).
-define(MAP_TRANSFER, 310).
-define(MAP_ROLE_KILLED, 311).
-define(MAP_GATE, 313).
-define(MAP_UPDATE_HP, 314).
-define(MAP_UPDATE_ROLE, 315).
-define(MAP_OTHER_ENTER, 316).
-define(FIGHT, 6).
-define(FIGHT_ATTACK, 601).
-define(FIGHT_WALK_FLY, 603).
-define(FIGHT_BEFORE_ATTACK, 604).
-define(FIGHT_BEGIN, 605).
-define(MOVE, 7).
-define(MOVE_WALK_PATH, 701).
-define(MOVE_WALK, 702).
-define(MOVE_SYNC, 705).
-define(MOVE_INFO, 710).
-define(EQUIP, 8).
-define(EQUIP_LOAD, 802).
-define(EQUIP_UNLOAD, 803).
-define(EQUIP_MOUNTUP, 807).
-define(EQUIP_MOUNTDOWN, 808).
-define(EQUIP_MOUNT_CHANGECOLOR, 809).
-define(EQUIP_DEL, 811).
-define(EQUIP_UPDATE, 816).
-define(EQUIP_REINFORCE, 828).
-define(EQUIP_INHERIT, 829).
-define(EQUIP_BUILD_INFO, 830).
-define(EQUIP_REBUILD, 831).
-define(EQUIP_BUILD, 832).
-define(EQUIP_BUILD_REFRESH, 833).
-define(EQUIP_FOSTER_REFRESH, 834).
-define(EQUIP_FOSTER_SAVE, 835).
-define(EQUIP_FOSTER_TRANSFER, 836).
-define(EQUIP_SHARE_INFO, 837).
-define(EQUIP_SHARE_LIST, 838).
-define(EQUIP_SHARE_SYNC, 839).
-define(EQUIP_SHARE_REQUEST, 841).
-define(EQUIP_SHARE_AGREE, 842).
-define(EQUIP_SHARE_REMOVE, 843).
-define(EQUIP_SHARE_EQUIPS, 844).
-define(EQUIP_SHARE_REQUESTER_ADD, 845).
-define(EQUIP_SHARE_REQUESTER_DEL, 846).
-define(EQUIP_BUILD_LIST, 847).
-define(FRIEND, 10).
-define(FRIEND_REQUEST, 1001).
-define(FRIEND_ACCEPT, 1002).
-define(FRIEND_DELETE, 1003).
-define(FRIEND_ONLINE, 1004).
-define(FRIEND_OFFLINE, 1005).
-define(FRIEND_BLACK, 1006).
-define(FRIEND_LIST, 1007).
-define(FRIEND_INFO, 1008).
-define(FRIEND_MODIFY, 1009).
-define(FRIEND_OFFLINE_REQUEST, 1010).
-define(FRIEND_REFUSE, 1011).
-define(FRIEND_ENEMY, 1012).
-define(FRIEND_CHANGE_RELATIVE, 1013).
-define(FRIEND_ADD_FRIENDLY, 1014).
-define(FRIEND_CREATE_FAMILY, 1015).
-define(FRIEND_UPGRADE, 1016).
-define(FRIEND_GET_INFO, 1017).
-define(FRIEND_UPDATE_FAMILY, 1018).
-define(FRIEND_RECOMMEND, 1019).
-define(FRIEND_CONGRATULATION, 1020).
-define(FRIEND_ADVERTISE, 1021).
-define(FRIEND_QUICK_REQUEST, 1022).
-define(FRIEND_AUTO_RECOMMEND, 1023).
-define(FRIEND_REQUEST_LIST, 1025).
-define(FRIEND_BLACK_LIST, 1026).
-define(FRIEND_SEARCH, 1027).
-define(FRIEND_AROUND_ROLE, 1028).
-define(FRIEND_RECENT_CONTACTS, 1029).
-define(FRIEND_BLACK_DELETE, 1030).
-define(FRIEND_ACCEPT_OR_REFUSE, 1031).
-define(FRIEND_SEND_LETTER, 1032).
-define(ITEM, 11).
-define(ITEM_USE, 1102).
-define(ITEM_GIFT, 1103).
-define(ITEM_TRACE, 1105).
-define(ITEM_USE_SPECIAL, 1107).
-define(ITEM_EXTEND_BAG_ROW, 1109).
-define(PET, 12).
-define(PET_ENTER, 1201).
-define(PET_QUIT, 1202).
-define(PET_DEAD, 1203).
-define(PET_ATTR_CHANGE, 1204).
-define(PET_SUMMON, 1205).
-define(PET_CALL_BACK, 1206).
-define(PET_INFO, 1207).
-define(PET_BAG_INFO, 1208).
-define(PET_COLLECT_LIST, 1209).
-define(PET_COLLECT_EAT, 1210).
-define(PET_ALL, 1211).
-define(PET_COLLECT_CHANGE, 1212).
-define(PET_COLLECT_NEW, 1213).
-define(SHOP, 13).
-define(SHOP_BUY, 1301).
-define(SHOP_SHOPS, 1302).
-define(SHOP_ALL_GOODS, 1303).
-define(SHOP_SEARCH, 1304).
-define(SHOP_NPC, 1305).
-define(SHOP_SALE, 1306).
-define(SHOP_ITEM, 1307).
-define(SHOP_BUY_BACK, 1308).
-define(COMMON, 14).
-define(COMMON_ERROR, 1401).
-define(COMMON_MSG, 1402).
-define(SKIN, 16).
-define(SKIN_CHANGE, 1601).
-define(TEAM, 17).
-define(TEAM_INVITE, 1701).
-define(TEAM_ACCEPT, 1702).
-define(TEAM_REFUSE, 1703).
-define(TEAM_LEAVE, 1704).
-define(TEAM_KICK, 1705).
-define(TEAM_OFFLINE, 1706).
-define(TEAM_CHANGE_LEADER, 1707).
-define(TEAM_DISBAND, 1708).
-define(TEAM_PICK, 1709).
-define(TEAM_AUTO_DISBAND, 1710).
-define(TEAM_AUTO_LIST, 1711).
-define(TEAM_MEMBER_INVITE, 1712).
-define(TEAM_MEMBER_RECOMMEND, 1713).
-define(TEAM_APPLY, 1714).
-define(TEAM_QUERY, 1715).
-define(TEAM_CREATE, 1716).
-define(TEAM_FB_CALL, 1723).
-define(TEAM_FB_TRANSFER, 1724).
-define(MONSTER, 18).
-define(MONSTER_ENTER, 1801).
-define(MONSTER_QUIT, 1802).
-define(MONSTER_DEAD, 1803).
-define(MONSTER_ATTR_CHANGE, 1804).
-define(MONSTER_WALK_PATH, 1805).
-define(MONSTER_WALK, 1806).
-define(MONSTER_SUMMON, 1807).
-define(MONSTER_TALK, 1808).
-define(MONSTER_QUERY, 1809).
-define(MONSTER_SKILL, 1810).
-define(LOTTO, 19).
-define(LOTTO_OPT, 1901).
-define(LOTTO_INFO, 1902).
-define(LOTTO_HISTORY, 1903).
-define(LOTTO_PLAY, 1904).
-define(GOODS, 20).
-define(GOODS_SWAP, 2002).
-define(GOODS_DESTROY, 2004).
-define(GOODS_DIVIDE, 2005).
-define(GOODS_UPDATE, 2006).
-define(GOODS_TIDY, 2007).
-define(GOODS_SHOW_GOODS, 2008).
-define(GOODS_SALE, 2011).
-define(LETTER, 21).
-define(LETTER_P2P_SEND, 2101).
-define(LETTER_GET, 2104).
-define(LETTER_OPEN, 2107).
-define(LETTER_DELETE, 2108).
-define(LETTER_ACCEPT_GOODS, 2110).
-define(LETTER_SEND, 2111).
-define(LETTER_FAMILY_SEND, 2112).
-define(EXCHANGE, 22).
-define(EXCHANGE_DEAL_ITEM, 2207).
-define(EXCHANGE_DEAL_SCORE, 2208).
-define(HANGING, 23).
-define(HANGING_OFFLINE, 2303).
-define(HANGING_STAT, 2305).
-define(HANGING_CHANGE, 2306).
-define(HANGING_WATCH, 2310).
-define(HANGING_WATCH_RESULT, 2311).
-define(HANGING_ROUND_START, 2312).
-define(HANGING_ROUND_END, 2313).
-define(HANGING_CONTINUE, 2314).
-define(HANGING_FB_RESULT, 2315).
-define(HANGING_BUFF, 2316).
-define(HANGING_READY, 2317).
-define(HANGING_DIALOG, 2318).
-define(FASHION, 25).
-define(FASHION_LIST, 2500).
-define(FASHION_UP, 2501).
-define(FASHION_DOWN, 2502).
-define(FASHION_UPGRADE, 2503).
-define(FASHION_AUTOUPGRADE, 2504).
-define(VERSION, 26).
-define(VERSION_NOTICE, 2601).
-define(DEPOT, 27).
-define(DEPOT_GET_GOODS, 2701).
-define(DEPOT_DREDGE, 2702).
-define(DEPOT_DESTROY, 2703).
-define(DEPOT_SWAP, 2704).
-define(DEPOT_DIVIDE, 2707).
-define(DEPOT_TIDY, 2708).
-define(DEPOT_EXTEND_ROW, 2710).
-define(SKILL, 28).
-define(SKILL_LIST, 2801).
-define(SKILL_SETTING, 2802).
-define(BROADCAST, 29).
-define(BROADCAST_GENERAL, 2901).
-define(BROADCAST_COUNTDOWN, 2902).
-define(BROADCAST_CYCLE, 2903).
-define(BROADCAST_ADMIN, 2904).
-define(BROADCAST_LABA, 2919).
-define(BROADCAST_STOP, 2920).
-define(FAMILY, 31).
-define(FAMILY_CREATE, 3101).
-define(FAMILY_REQUEST, 3102).
-define(FAMILY_INVITE, 3103).
-define(FAMILY_AGREE, 3104).
-define(FAMILY_REFUSE, 3105).
-define(FAMILY_AGREE_F, 3106).
-define(FAMILY_REFUSE_F, 3107).
-define(FAMILY_FIRE, 3108).
-define(FAMILY_UNSET_SECOWNER_OR_ELDER, 3109).
-define(FAMILY_UPDATE_NOTICE, 3111).
-define(FAMILY_LEAVE, 3113).
-define(FAMILY_DISMISS, 3114).
-define(FAMILY_LIST, 3115).
-define(FAMILY_SET_TITLE, 3116).
-define(FAMILY_SET_OWNER, 3117).
-define(FAMILY_SET_SECOWNER_OR_ELDER, 3118).
-define(FAMILY_SELF, 3119).
-define(FAMILY_MEMBER_JOIN, 3120).
-define(FAMILY_PANEL, 3121).
-define(FAMILY_ENTER_MAP, 3122).
-define(FAMILY_LEAVE_MAP, 3123).
-define(FAMILY_CANCEL_INVITE, 3128).
-define(FAMILY_ROLE_ONLINE, 3129).
-define(FAMILY_ROLE_OFFLINE, 3130).
-define(FAMILY_CAN_INVITE, 3131).
-define(FAMILY_CANCEL_TITLE, 3132).
-define(FAMILY_ENABLE_MAP, 3133).
-define(FAMILY_UPLEVEL, 3134).
-define(FAMILY_ACTIVE_POINTS, 3135).
-define(FAMILY_DOWNLEVEL, 3136).
-define(FAMILY_MONEY, 3137).
-define(FAMILY_SEARCH, 3138).
-define(FAMILY_CALLMEMBER, 3139).
-define(FAMILY_MEMBER_ENTER_MAP, 3140).
-define(FAMILY_MAINTAINFAIL, 3141).
-define(FAMILY_MEMBERUPLEVEL, 3142).
-define(FAMILY_MEMBERGATHER, 3143).
-define(FAMILY_GATHERREQUEST, 3155).
-define(FAMILY_DETAIL, 3157).
-define(FAMILY_MAP_CLOSED, 3162).
-define(FAMILY_DEL_REQUEST, 3163).
-define(FAMILY_INFO_CHANGE, 3164).
-define(FAMILY_SET_BONFIRE_START_TIME, 3168).
-define(FAMILY_ACTIVESTATE, 3169).
-define(FAMILY_SET_INTERIOR_MANAGER, 3170).
-define(FAMILY_LEFTRIGHT_PROTECTOR, 3171).
-define(FAMILY_UNSET_INTERIOR_MANAGER, 3172).
-define(FAMILY_NOTIFY_ONLINE, 3173).
-define(FAMILY_GET_DONATE_INFO, 3174).
-define(FAMILY_DONATE, 3175).
-define(FAMILY_CALL_PARTYBOSS, 3176).
-define(FAMILY_AUTO_AGREE, 3177).
-define(FAMILY_BOSS_CALL, 3180).
-define(FAMILY_BOSS_INFO, 3181).
-define(FAMILY_BACKOUT, 3182).
-define(FAMILY_JOIN_LIMIT, 3183).
-define(FAMILY_REQUEST_LIST, 3184).
-define(FAMILY_BOSS_ATTACK, 3185).
-define(FAMILY_BOSS_REWARD, 3186).
-define(FAMILY_BOSS_NOTICE, 3187).
-define(SHORTCUT, 32).
-define(SHORTCUT_INIT, 3201).
-define(SHORTCUT_UPDATE, 3202).
-define(BUBBLE, 33).
-define(BUBBLE_SEND, 3301).
-define(BUBBLE_MSG, 3302).
-define(SYSTEM, 36).
-define(SYSTEM_FCM, 3601).
-define(SYSTEM_CONFIG, 3602).
-define(SYSTEM_CONFIG_CHANGE, 3603).
-define(SYSTEM_HEARTBEAT, 3604).
-define(SYSTEM_ERROR, 3605).
-define(SYSTEM_MESSAGE, 3606).
-define(SYSTEM_SETTING, 3607).
-define(SYSTEM_APNS, 3608).
-define(SYSTEM_PAY, 3609).
-define(DANYAO, 37).
-define(DANYAO_INFO, 3701).
-define(DANYAO_EAT, 3702).
-define(GM, 40).
-define(GM_COMPLAINT, 4001).
-define(GM_SCORE, 4002).
-define(RANKING, 41).
-define(RANKING_GET_RANK, 4102).
-define(RANKING_ROLE_ALL_RANK, 4111).
-define(TITLE, 44).
-define(TITLE_GET_ROLE_TITLES, 4401).
-define(TITLE_CHANGE_CUR_TITLE, 4402).
-define(SERVER_NPC, 50).
-define(SERVER_NPC_ENTER, 5001).
-define(SERVER_NPC_QUIT, 5002).
-define(SERVER_NPC_DEAD, 5003).
-define(ACTIVITY, 56).
-define(ACTIVITY_TODAY, 5601).
-define(ACTIVITY_BENEFIT_LIST, 5605).
-define(ACTIVITY_BENEFIT_REWARD, 5606).
-define(ACTIVITY_BENEFIT_BUY, 5607).
-define(ACTIVITY_GETGIFT, 5608).
-define(ACTIVITY_PAY_GIFT_INFO, 5609).
-define(ACTIVITY_BOSS_GROUP, 5610).
-define(ACTIVITY_NOTICE_START, 5611).
-define(ACTIVITY_NOTICE_END, 5612).
-define(ACTIVITY_NOTICE_TRANSFER, 5613).
-define(ACTIVITY_EXP_BACK_FETCH, 5615).
-define(ACTIVITY_SCHEDULE_INFO, 5617).
-define(ACTIVITY_SCHEDULE_FETCH, 5618).
-define(ACTIVITY_TODAY_UPDATE, 5619).
-define(ACTIVITY_DRUNK_TIME, 5620).
-define(ACTIVITY_DAILY_PAY_REWARD, 5621).
-define(ACTIVITY_DAILY_PAY_NOTIFY, 5622).
-define(ACTIVITY_GATHER, 5623).
-define(ACTIVITY_GATHER_INFO, 5624).
-define(ACTIVITY_FECTH, 5625).
-define(ACTIVITY_POINT_BUY, 5627).
-define(ACTIVITY_YUNYING_INFO, 5628).
-define(ACTIVITY_COMPLETION_INFO, 5629).
-define(ACTIVITY_COMPLETION_POINT, 5630).
-define(ACTIVITY_COMPLETION_FETCH, 5631).
-define(ACTIVITY_OPEN_ACTIVITY_STATUS, 5632).
-define(ACTIVITY_OPEN_ACTIVITY_INFO, 5633).
-define(ACTIVITY_OPEN_ACTIVITY_RANK, 5635).
-define(ACTIVITY_RECOMMEND, 5636).
-define(NEWCOMER, 57).
-define(NEWCOMER_ACTIVATE_CODE, 5701).
-define(NEWCOMER_ONLINETIME_INFO, 5706).
-define(NEWCOMER_ONLINETIME_FETCH, 5707).
-define(LEVEL_GIFT, 62).
-define(LEVEL_GIFT_LIST, 6201).
-define(LEVEL_GIFT_ACCEPT, 6202).
-define(STAT, 64).
-define(STAT_CLIENT_OS, 6401).
-define(STAT_CONFIG, 6402).
-define(STAT_BROWSER, 6403).
-define(PRESENT, 68).
-define(PRESENT_NOTIFY, 6801).
-define(PRESENT_GET, 6802).
-define(PRESENT_REDBAG, 6803).
-define(FMLSHOP, 49).
-define(FMLSHOP_ERROR, 4900).
-define(FMLSHOP_LIST, 4901).
-define(FMLSHOP_ADD, 4902).
-define(FMLSHOP_BUY, 4903).
-define(VIP, 74).
-define(VIP_ACTIVE, 7401).
-define(VIP_INFO, 7403).
-define(VIP_STOP_NOTIFY, 7404).
-define(VIP_REMOTE_DEPOT, 7406).
-define(VIP_REBACK_GOLD, 7407).
-define(VIP_REWARD, 7408).
-define(VIP_SUPER_INFO, 7409).
-define(VIP_REWARD_INFO, 7410).
-define(VIP_CONSUME_NOTICE, 7411).
-define(VIP_BUY_BUFF, 7412).
-define(VIP_NOTICE, 7413).
-define(VIP_NEXT_INFO, 7414).
-define(VIP_GIFT, 7415).
-define(VIP_SELL_INFO, 7416).
-define(VIP_SELL, 7417).
-define(SCENE_WAR_FB, 76).
-define(SCENE_WAR_FB_ENTER, 7601).
-define(SCENE_WAR_FB_QUERY, 7603).
-define(SCENE_WAR_FB_END, 7607).
-define(MAIN_FB, 81).
-define(MAIN_FB_INFO, 8101).
-define(MAIN_FB_SELECT, 8102).
-define(MAIN_FB_SWEEP, 8103).
-define(MAIN_FB_BUY, 8104).
-define(MAIN_FB_QUICK, 8105).
-define(MAIN_FB_PASS_BOSS, 8106).
-define(RANKREWARD, 90).
-define(RANKREWARD_INFO, 9001).
-define(RANKREWARD_LIST, 9002).
-define(RANKREWARD_FETCH_REWARD, 9003).
-define(NATIONBATTLE, 91).
-define(NATIONBATTLE_ENTER, 9101).
-define(NATIONBATTLE_QUIT, 9102).
-define(NATIONBATTLE_TRANSFER, 9103).
-define(NATIONBATTLE_INFO, 9104).
-define(NATIONBATTLE_RANK, 9105).
-define(NATIONBATTLE_CHANGE, 9106).
-define(NATIONBATTLE_REWARD, 9107).
-define(NATIONBATTLE_FETCH_REWARD, 9108).
-define(PVE_FB, 94).
-define(PVE_FB_BUFF_LIST, 9401).
-define(PVE_FB_BUY_BUFF, 9402).
-define(QQ, 96).
-define(QQ_AUTH, 9601).
-define(QQ_BUY_GOLD, 9602).
-define(QQ_INFO, 9603).
-define(CAISHEN, 100).
-define(CAISHEN_SILVER_INFO, 10001).
-define(CAISHEN_SILVER_FETCH, 10002).
-define(CAISHEN_FIRECOIN_INFO, 10003).
-define(CAISHEN_FIRECOIN_FETCH, 10004).
-define(CAISHEN_CONFIRM, 10005).
-define(SHENQI, 104).
-define(SHENQI_EAT, 10401).
-define(SHENQI_TRANSFER, 10402).
-define(BIGPVE, 106).
-define(BIGPVE_ENTER, 10601).
-define(BIGPVE_QUIT, 10602).
-define(BIGPVE_INFO, 10603).
-define(BIGPVE_RANK, 10604).
-define(BIGPVE_BOSS_DEAD, 10605).
-define(BIGPVE_BUY_BUFF, 10606).
-define(BIGPVE_RESULT, 10607).
-define(BIGPVE_BOMB, 10608).
-define(BIGPVE_LOWER_HP_NOTIFY, 10609).
-define(ROUND_PVP, 108).
-define(ROUND_PVP_HISTORY, 10801).
-define(ROUND_PVP_INFO, 10802).
-define(ROUND_PVP_REWARD, 10803).
-define(ROUND_PVP_FB_STATE, 10804).
-define(ROUND_PVP_FB_RESULT, 10805).
-define(ROUND_PVP_HALL_INFO, 10806).
-define(MONSTER_WAR, 109).
-define(MONSTER_WAR_INFO, 10901).
-define(MONSTER_WAR_WAVE, 10902).
-define(MONSTER_WAR_HISTORY, 10903).
-define(GRAB, 110).
-define(GRAB_OPEN, 11001).
-define(GRAB_CHALLENGE, 11002).
-define(GRAB_REFRESH, 11003).
-define(GRAB_ADD_PROTECT, 11004).
-define(GRAB_RESULT, 11005).
-define(GRAB_SELECT_REWARD, 11006).
-define(GRAB_ADD_CHANCE, 11007).
-define(GRAB_UPDATE_ROLE, 11008).
-define(GRAB_FAST_FIGHT, 11009).
-define(RNKM, 112).
-define(RNKM_ERROR, 11201).
-define(RNKM_OPEN, 11202).
-define(RNKM_CLOSE, 11203).
-define(RNKM_CHALLENGE, 11204).
-define(RNKM_UPDATE_ROLE, 11205).
-define(RNKM_UPDATE_MIRROR, 11206).
-define(RNKM_ADD_CHANCE, 11209).
-define(RNKM_NOTIFY, 11216).
-define(RNKM_SCORE_DEAL, 11217).
-define(RNKM_REFRESH, 11218).
-define(RNKM_RESULT, 11220).
-define(SINGLE_FB, 113).
-define(SINGLE_FB_INFO, 11301).
-define(SINGLE_FB_FIGHT, 11302).
-define(FAMILY_FB, 114).
-define(FAMILY_FB_INFO, 11401).
-define(FAMILY_FB_FIGHT, 11402).
-define(FAMILY_FB_RESULT, 11403).
-define(FAMILY_WELFARE, 116).
-define(FAMILY_WELFARE_ERROR, 11600).
-define(FAMILY_WELFARE_GET, 11601).
-define(FAMILY_IDOL, 117).
-define(FAMILY_IDOL_ERROR, 11700).
-define(FAMILY_IDOL_OPEN, 11701).
-define(FAMILY_IDOL_PRAY, 11703).
-define(FAMILY_IDOL_UPDATE, 11704).
-define(TREASBOX, 118).
-define(TREASBOX_SHOW, 11801).
-define(TREASBOX_OPEN, 11802).
-define(TREASBOX_GET, 11803).
-define(TREASBOX_REFRESH, 11804).
-define(TREASBOX_LOG, 11805).
-define(SMS, 119).
-define(SMS_SEND, 11901).
-define(SMS_NOTIFY, 11902).
-define(GIFT_LIMITED, 154).
-define(GIFT_LIMITED_SHOW, 15400).
-define(GIFT_LIMITED_FETCH, 15401).
-define(GIFT_LIMITED_OPEN, 15402).
-define(ROLE_GOAL, 155).
-define(ROLE_GOAL_INFO, 15500).
-define(ROLE_GOAL_FETCH, 15501).
-define(ROLE_GOAL_REACH, 15502).
-define(MOUNT, 167).
-define(MOUNT_LIST, 16700).
-define(MOUNT_UP, 16701).
-define(MOUNT_DOWN, 16702).
-define(MOUNT_UPGRADE, 16703).
-define(MOUNT_CHANGEUP, 16704).
-define(MOUNT_AUTOUPGRADE, 16705).
-define(MOUNT_CHANGEDOWN, 16706).
-define(MOUNT_FORCEUP, 16707).
-define(MOUNT_FORCEDOWN, 16708).
-define(MOUNT_EVOLVE, 16709).
-define(ACHIEVEMENT, 168).
-define(ACHIEVEMENT_INFO, 16800).
-define(ACHIEVEMENT_FETCH, 16801).
-define(ACHIEVEMENT_UPDATE, 16802).
-define(ROOM, 171).
-define(ROOM_CREATE, 17100).
-define(ROOM_LIST, 17101).
-define(ROOM_JOIN, 17102).
-define(ROOM_SELF, 17103).
-define(ROOM_EXIT, 17104).
-define(ROOM_KICK, 17105).
-define(COMMON_FB, 173).
-define(COMMON_FB_ENTER, 17301).
-define(COMMON_FB_QUIT, 17302).
-define(COMMON_FB_LOST_MONSTER, 17303).
-define(COMMON_FB_LIANZHAN, 17304).
-define(COMMON_FB_COLLECT_BOX, 17305).
-define(COMMON_FB_ENTER_TIMES, 17306).
-define(COMMON_FB_KILL_REPORT, 17307).
-define(COMMON_FB_MIRRORS, 17308).
-define(GENGU, 175).
-define(GENGU_INFO, 17501).
-define(GENGU_UPGRADE, 17502).
-define(GENGU_AUTOUPGRADE, 17503).
-define(COMPARE_SELL, 176).
-define(COMPARE_SELL_INFO, 17600).
-define(COMPARE_SELL_FETCH, 17601).
-define(TEAM_MIRROR, 179).
-define(TEAM_MIRROR_INFO, 17900).
-define(TEAM_MIRROR_ENTER, 17901).
-define(TEAM_MIRROR_QUIT, 17902).
-define(TEAM_MIRROR_REPORT, 17903).
-define(TEAM_MIRROR_GET_FRIENDS, 17904).
-define(FAMILY_WAR, 180).
-define(FAMILY_WAR_SCORE, 18001).
-define(FAMILY_WAR_MY_BUFFS, 18002).
-define(FAMILY_WAR_USE_BUFF, 18003).
-define(FAMILY_WAR_COMMIT_MEDICINE, 18004).
-define(UNIT, 182).
-define(UNIT_ATTACK, 18201).
-define(UNIT_ENTER, 18202).
-define(UNIT_QUIT, 18203).
-define(UNIT_DEAD, 18204).
-define(SUPER_MISSION, 185).
-define(SUPER_MISSION_OPT, 18501).
-define(SUPER_MISSION_INFO, 18502).
-define(SUPER_MISSION_SHOW, 18503).
-define(CD, 187).
-define(CD_INFO, 18701).
-define(CD_CLEAR, 18702).
-define(CD_FREE_HUNT, 18703).
-define(CD_FREE_NOTICE, 18704).
-define(DAILY_ACTIVITY, 186).
-define(DAILY_ACTIVITY_INFO, 18601).
-define(DAILY_ACTIVITY_COUNTER, 18602).
-define(DAILY_ACTIVITY_GUIDE, 18603).
-define(DAILY_ACTIVITY_FORECAST, 18604).
-define(DAILY_BENEFIT, 188).
-define(DAILY_BENEFIT_INFO, 18801).
-define(DAILY_BENEFIT_FETCH, 18802).
-define(FUND, 189).
-define(FUND_INFO, 18900).
-define(FUND_ACTIVE, 18901).
-define(FUND_FETCH, 18902).
-define(FUND_LEVEL_INFO, 18903).
-define(FUND_LEVEL_BUY, 18904).
-define(FUND_LEVEL_FETCH, 18905).
-define(GUIDE, 190).
-define(GUIDE_INFO, 19001).
-define(GUIDE_FINISH, 19002).
-define(LOGIN_REWARD, 191).
-define(LOGIN_REWARD_INFO, 19100).
-define(LOGIN_REWARD_FETCH, 19101).
-define(TOWER_FB, 193).
-define(TOWER_FB_ENTER, 19301).
-define(TOWER_FB_QUIT, 19302).
-define(TOWER_FB_INFO, 19303).
-define(TOWER_FB_REWARD, 19304).
-define(TOWER_FB_RESULT, 19305).
-define(TOWER_FB_STATUS, 19306).
-define(BEST_TOWER_FB, 194).
-define(BEST_TOWER_FB_INFO, 19401).
-define(TIME_ACTIVITY, 195).
-define(TIME_ACTIVITY_INFO, 19501).
-define(TIME_ACTIVITY_FETCH, 19502).
-define(TIME_ACTIVITY_UPDATE, 19503).
-define(TIME_ACTIVITY_ORG_FETCH, 19504).
-define(SIGNIN, 196).
-define(SIGNIN_OPERATE, 19601).
-define(WILD_FB, 197).
-define(WILD_FB_ENTER, 19701).
-define(WILD_FB_EXIT, 19702).
-define(PAYMENT, 199).
-define(PAYMENT_INFO, 19901).
-define(PAYMENT_FETCH, 19902).
-define(PAYMENT_REQUEST, 19903).
-define(HOLIDAY_ACT, 201).
-define(HOLIDAY_ACT_INFO, 20101).
-define(HOLIDAY_ACT_OPERATE, 20102).
-define(HOLIDAY_ACT_GOLD_HISTORY, 20103).
-define(STONE, 202).
-define(STONE_OPT, 20201).
-define(STONE_EAT, 20202).
-define(FMLBONUS, 203).
-define(FMLBONUS_LIST, 20301).
-define(FMLBONUS_DONATE, 20302).
-define(FMLBONUS_SEND, 20303).
-define(FMLBONUS_GET, 20304).
-define(FMLBONUS_SEND_HISTORY, 20305).
-define(FMLMATCH, 204).
-define(FMLMATCH_INFO, 20401).
-define(FMLMATCH_VIEW_FIGHTING, 20402).
-define(FMLMATCH_START, 20403).
-define(FMLMATCH_END, 20404).
-define(DOWNLOAD_TASK, 205).
-define(DOWNLOAD_TASK_INFO, 20501).
-define(DOWNLOAD_TASK_FETCH, 20502).
-define(MISSION, 15).
-define(MISSION_LIST, 1501).
-define(MISSION_DO, 1502).
-define(MISSION_CANCEL, 1503).
-define(MISSION_UPDATE, 1504).
-define(MISSION_LISTENER, 1505).
-define(MISSION_LIST_AUTO, 1506).
-define(MISSION_DO_AUTO, 1507).
-define(MISSION_CANCEL_AUTO, 1508).
-define(MISSION_TOUCH_SET, 1509).
-define(MISSION_SHOW_PROP, 1510).
-define(MISSION_STAR, 1511).
