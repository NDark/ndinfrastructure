# P_JSONParsersPerformance von ndInfrastructure

## Test Result 

Test case:httpswww.mockaroo.com.json.txt Test method(0) watch.ElapsedMilliseconds=9
Test case:httpswww.mockaroo.com.json.txt Test method(1) watch.ElapsedMilliseconds=10
Test case:httpswww.mockaroo.com.json.txt Test method(2) watch.ElapsedMilliseconds=1119
Test case:httpswww.mockaroo.com.json.txt Test method(3) watch.ElapsedMilliseconds=3
Test case:httpswww.mockaroo.com.json.txt Test method(4) watch.ElapsedMilliseconds=5
Test case:httpswww.mockaroo.com.json.txt Test method(5) watch.ElapsedMilliseconds=4
Test case:httpswww.mockaroo.com.json.txt Test method(6) watch.ElapsedMilliseconds=4
Test case:httpswww.mockaroo.com.json.txt Test method(7) watch.ElapsedMilliseconds=46
Test case:httpswww.mockaroo.com.json.txt Test method(8) watch.ElapsedMilliseconds=43
Test case:httpswww.mockaroo.com.json.txt Test method(9) watch.ElapsedMilliseconds=46
Test case:httpswww.mockaroo.com.json.txt Test method(10) watch.ElapsedMilliseconds=11
Test case:httpswww.mockaroo.com.json.txt Test method(11) watch.ElapsedMilliseconds=14
Test case:httpswww.mockaroo.com.json.txt Test method(12) watch.ElapsedMilliseconds=3
Test case:httpwww.txtwizard.netcompression.txt Test method(0) watch.ElapsedMilliseconds=2195
Test case:httpwww.txtwizard.netcompression.txt Test method(1) watch.ElapsedMilliseconds=2249
Test case:httpwww.txtwizard.netcompression.txt Test method(2) watch.ElapsedMilliseconds=1
Test case:httpwww.txtwizard.netcompression.txt Test method(3) watch.ElapsedMilliseconds=1
Test case:httpwww.txtwizard.netcompression.txt Test method(4) watch.ElapsedMilliseconds=1
Test case:httpwww.txtwizard.netcompression.txt Test method(5) watch.ElapsedMilliseconds=1
Test case:httpwww.txtwizard.netcompression.txt Test method(6) watch.ElapsedMilliseconds=1
Test case:httpwww.txtwizard.netcompression.txt Test method(7) watch.ElapsedMilliseconds=0
Test case:httpwww.txtwizard.netcompression.txt Test method(8) watch.ElapsedMilliseconds=0
Test case:httpwww.txtwizard.netcompression.txt Test method(9) watch.ElapsedMilliseconds=0
Test case:httpwww.txtwizard.netcompression.txt Test method(10) watch.ElapsedMilliseconds=0
Test case:httpwww.txtwizard.netcompression.txt Test method(11) watch.ElapsedMilliseconds=1
Test case:httpwww.txtwizard.netcompression.txt Test method(12) watch.ElapsedMilliseconds=0


## Test Cases

1. httpswww.mockaroo.com.json.txt : one-thousand-row strctured items.
1. httpwww.txtwizard.netcompression.txt : long string without structure.


## Test Methods

1. 0: TryParseContent_SimpleJSON20121217(content);
1. 1: TryParseContent_SimpleJSON20121217_StringBuilderEscape(content);
1. 2: TryParseContent_SimpleJSON_20121217_StringBuilderEscapeToken(content);
1. 3: TryParseContent_SimpleJSON_20121217_StringBuilderEscapeTokenCapacity(content);
1. 4: TryParseContent_SimpleJSON_20140921_StringBuilderEscapeTokenNumberize(content);
1. 5: TryParseContent_SimpleJSON_20170308_StringBuilderEscapeTokenJSONObject(content);
1. 6: TryParseContent_SimpleJSON_20170411_JSONTextModeToString(content);
1. 7: TryParseContent_NewtonJSON_6_0_8(content);
1. 8: TryParseContent_NewtonJSON_9_0_1(content);
1. 9: TryParseContent_NewtonJSON_10_0_2(content);
1. 10: TryParseContent_SimpleJson0360(content);
1. 11: TryParseContent_LightJson022(content);
1. 12: TryParseContent_fastJSON2124(content);

