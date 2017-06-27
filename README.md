# P_JSONParsersPerformance von ndInfrastructure

## Test Results

* Test case:httpswww.mockaroo.com.json.txt Test method(0) watch.ElapsedMilliseconds=11
* Test case:httpswww.mockaroo.com.json.txt Test method(1) watch.ElapsedMilliseconds=10
* Test case:httpswww.mockaroo.com.json.txt Test method(2) watch.ElapsedMilliseconds=986
* Test case:httpswww.mockaroo.com.json.txt Test method(3) watch.ElapsedMilliseconds=3
* Test case:httpswww.mockaroo.com.json.txt Test method(4) watch.ElapsedMilliseconds=5
* Test case:httpswww.mockaroo.com.json.txt Test method(5) watch.ElapsedMilliseconds=4
* Test case:httpswww.mockaroo.com.json.txt Test method(6) watch.ElapsedMilliseconds=4
* Test case:httpswww.mockaroo.com.json.txt Test method(7) watch.ElapsedMilliseconds=46
* Test case:httpswww.mockaroo.com.json.txt Test method(8) watch.ElapsedMilliseconds=41
* Test case:httpswww.mockaroo.com.json.txt Test method(9) watch.ElapsedMilliseconds=43
* Test case:httpswww.mockaroo.com.json.txt Test method(10) watch.ElapsedMilliseconds=11
* Test case:httpswww.mockaroo.com.json.txt Test method(11) watch.ElapsedMilliseconds=14
* Test case:httpswww.mockaroo.com.json.txt Test method(12) watch.ElapsedMilliseconds=3
* Test case:httpswww.mockaroo.com.json.txt Test method(13) watch.ElapsedMilliseconds=17
* Test case:httpswww.mockaroo.com.json.txt Test method(14) watch.ElapsedMilliseconds=4
* Test case:httpwww.txtwizard.netcompression.txt Test method(0) watch.ElapsedMilliseconds=2276
* Test case:httpwww.txtwizard.netcompression.txt Test method(1) watch.ElapsedMilliseconds=2207
* Test case:httpwww.txtwizard.netcompression.txt Test method(2) watch.ElapsedMilliseconds=1
* Test case:httpwww.txtwizard.netcompression.txt Test method(3) watch.ElapsedMilliseconds=1
* Test case:httpwww.txtwizard.netcompression.txt Test method(4) watch.ElapsedMilliseconds=1
* Test case:httpwww.txtwizard.netcompression.txt Test method(5) watch.ElapsedMilliseconds=1
* Test case:httpwww.txtwizard.netcompression.txt Test method(6) watch.ElapsedMilliseconds=1
* Test case:httpwww.txtwizard.netcompression.txt Test method(7) watch.ElapsedMilliseconds=0
* Test case:httpwww.txtwizard.netcompression.txt Test method(8) watch.ElapsedMilliseconds=0
* Test case:httpwww.txtwizard.netcompression.txt Test method(9) watch.ElapsedMilliseconds=0
* Test case:httpwww.txtwizard.netcompression.txt Test method(10) watch.ElapsedMilliseconds=0
* Test case:httpwww.txtwizard.netcompression.txt Test method(11) watch.ElapsedMilliseconds=1
* Test case:httpwww.txtwizard.netcompression.txt Test method(12) watch.ElapsedMilliseconds=0
* Test case:httpwww.txtwizard.netcompression.txt Test method(13) watch.ElapsedMilliseconds=1
* Test case:httpwww.txtwizard.netcompression.txt Test method(14) watch.ElapsedMilliseconds=1



## Test Cases

1. httpswww.mockaroo.com.json.txt : one-thousand-row strctured items.
1. httpwww.txtwizard.netcompression.txt : long string without structure.


## Test Methods

* 0: TryParseContent_SimpleJSON20121217(content);
* 1: TryParseContent_SimpleJSON20121217_StringBuilderEscape(content);
* 2: TryParseContent_SimpleJSON_20121217_StringBuilderEscapeToken(content);
* 3: TryParseContent_SimpleJSON_20121217_StringBuilderEscapeTokenCapacity(content);
* 4: TryParseContent_SimpleJSON_20140921_StringBuilderEscapeTokenNumberize(content);
* 5: TryParseContent_SimpleJSON_20170308_StringBuilderEscapeTokenJSONObject(content);
* 6: TryParseContent_SimpleJSON_20170411_JSONTextModeToString(content);
* 7: TryParseContent_NewtonJSON_6_0_8(content);
* 8: TryParseContent_NewtonJSON_9_0_1(content);
* 9: TryParseContent_NewtonJSON_10_0_2(content);
* 10: TryParseContent_SimpleJson0360(content);
* 11: TryParseContent_LightJson022(content);
* 12: TryParseContent_fastJSON2124(content);
* 13: TryParseContent_LitJSON090(content);
* 14: TryParseContent_MiniJSON20130602(content);


# References

1. http://wiki.unity3d.com/index.php/SimpleJSON
1. https://github.com/Bunny83/SimpleJSON
1. https://github.com/opless/SimpleJSON
1. https://github.com/CymaticLabs/Unity3D.Amqp
1. http://www.newtonsoft.com/json
1. https://www.nuget.org/packages/SimpleJson/
1. https://github.com/MarcosLopezC/LightJson
1. https://github.com/alibaba/fastjson
1. https://github.com/lbv/litjson
1. https://gist.github.com/darktable/1411710

