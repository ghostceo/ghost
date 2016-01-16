<?php
// 	$json = '{"orderId":193261481,"appKeyId":100029655,"buyerId":110734509,"cardNo":null,"money":10,"chargeType"
// :"BALANCEPAY","timeStamp":1438437438843,"out_trade_no":"104_1:129:1:1:wandoujia_49babaddb891c74e0e571e42d9d31737"}
// '; 
// 	//var_dump(json_decode($json)); 
// 	//var_dump(json_decode($json, true));
// 	print_r(json_decode($json,true));
// 	$arr = array ('a'=>1,'b'=>2,'c'=>3,'d'=>4,'e'=>5); 
//     echo json_encode($arr); 


	// $start_time = time();
	// echo $start_time;
	// $MD = md5("tlz中国");
	// echo $MD;
	// $f="a_1.JPG";
	// $strs = explode("_",$f);
	// $id = str_replace('.JPG','',$strs[1]);
	// $k = is_dir("D:/heros/");

 //    // echo file_get_contents("cfg_item.iex")
 //    exec("php D:/test/cfg_gift.php cfg_gift.erl D:/test/iex/cfg_gift.iex");
	// print_r($id);
    // $not_build_file = array(
//     '00_player.txt',
//     '99_admin.txt',
//     '100_mobile.txt'
// );

// $mod_list = array();
// $action_list = array();

// for ($i = 0; $i < 10; $i++) {
//     //120,156用于压缩包头识别
//     if (in_array($i, array(0, 99))) {
//         continue;
//     }
//     array_push($mod_list, $i);
//     array_push($action_list, $i);
// }
// $protocol_dir = dirname(__FILE__) . '\doc\proto'."\\";
// print_r($protocol_dir);
// $dir_fp = opendir($protocol_dir);

// $match = array();
// $file_list = array();
// while ($file_name = readdir($dir_fp)) {
//     if ($file_name != "." && $file_name != "..") {
//         array_push($file_list, $file_name);
//     }
// }


// print_r($file_list);
// foreach ($file_list as $file_name) {
//     if (in_array($file_name, $not_build_file)) {
//         continue;
//     }
//     $the_action_list = $action_list;

//     $file_path = "{$protocol_dir}{$file_name}";
//     $file_content = '';

//     $fp = fopen($file_path, 'r');
//     $is_mod_line = false;
//     while (!feof($fp)) {
//         $match_list = array();
//         $line = fgets($fp);
//         if (preg_match_all('/=\s*\d{1,}/', $line, $match_list)) {
//             $match_value_list = $match_list[0];
//             foreach ($match_value_list as $match_value) {
//                 $n = 0;
//                 if (!$is_mod_line) {
//                     list($n, $mod_list) = rand_value($mod_list);
//                     $is_mod_line = true;
//                 }
//                 else {
//                     list($n, $the_action_list) = rand_value($the_action_list);
//                 }
//                 $new_match_value = preg_replace('/\d{1,}/', $n, $match_value);
//                 $line = str_replace($match_value, $new_match_value, $line);
//             }
//         } 

//         $file_content .= $line;
//     }
//     fclose($fp);

//     file_put_contents($file_path, $file_content);
// }


// function rand_value ($arr) {
//     $i = rand(0, count($arr) - 1);
//     $value = $arr[$i];
    
//     unset($arr[$i]);

//     return array(
//         $value,
//         array_values($arr)
//     );
// }

//<?php
//$apiKey = "e8a8922d5929f65cb69f95f3dc806ab5"; 
//$apiURL = "http://www.tuling123.com/openapi/api?key=KEY&info=INFO";

// 设置报文头, 构建请求报文 
//header("Content-type: text/html; charset=utf-8"); 
//$reqInfo = "中国"; 
//$url = str_replace("INFO", $reqInfo, str_replace("KEY", $apiKey, $apiURL)); 

/** 方法一、用file_get_contents 以get方式获取内容 */ 
     // $res =file_get_contents($url); 
     // echo $res; 

/** 方法二、使用curl库，需要查看php.ini是否已经打开了curl扩展 */ 
//    $ch = curl_init(); 
//    $timeout = 5; curl_setopt ($ch, CURLOPT_URL, $url); curl_setopt ($ch, CURLOPT_RETURNTRANSFER, 1); 
//    curl_setopt ($ch, CURLOPT_CONNECTTIMEOUT, $timeout); 
//    $file_contents = curl_exec($ch); 
//    curl_close($ch); 
    //echo $file_contents;
//    $obj = json_decode($file_contents);
//   print_r($obj->text);
//?>
?>

