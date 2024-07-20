/// @DnDAction : YoYo Games.Common.Execute_Code
/// @DnDVersion : 1
/// @DnDHash : 678F7D4C
/// @DnDArgument : "code" "// Example in Create Event of obj_data_blocks$(13_10)self.usedNumbers = ds_list_create();$(13_10)$(13_10)randomize();$(13_10)$(13_10)var datablockCounts = obj_Index.a;$(13_10)var strdatablockCount = string(datablockCounts) + "~~";$(13_10)$(13_10)ds_list_add(self.usedNumbers, datablockCounts);$(13_10)self.resultString = string(datablockCounts);$(13_10)$(13_10)var randomInteger;$(13_10)$(13_10)for (var i = 1; i <= datablockCounts; i++) {$(13_10)    do {$(13_10)        randomInteger = floor(random_range(0, 19 + 1));$(13_10)    } until (randomInteger != datablockCounts && ds_list_find_index(self.usedNumbers, randomInteger) == -1);$(13_10)$(13_10)    ds_list_add(self.usedNumbers, randomInteger);$(13_10)$(13_10)    if (self.resultString != "") {$(13_10)        self.resultString += ", ";$(13_10)    }$(13_10)$(13_10)    self.resultString += string(randomInteger);$(13_10)}$(13_10)$(13_10)self.resultString = string_delete(self.resultString, 0, string_length(strdatablockCount));$(13_10)ds_list_delete(self.usedNumbers, ds_list_find_index(self.usedNumbers, datablockCounts));$(13_10)"
// Example in Create Event of obj_data_blocks
self.usedNumbers = ds_list_create();

randomize();

var datablockCounts = obj_Index.a;
var strdatablockCount = string(datablockCounts) + "~~";

ds_list_add(self.usedNumbers, datablockCounts);
self.resultString = string(datablockCounts);

var randomInteger;

for (var i = 1; i <= datablockCounts; i++) {
    do {
        randomInteger = floor(random_range(0, 19 + 1));
    } until (randomInteger != datablockCounts && ds_list_find_index(self.usedNumbers, randomInteger) == -1);

    ds_list_add(self.usedNumbers, randomInteger);

    if (self.resultString != "") {
        self.resultString += ", ";
    }

    self.resultString += string(randomInteger);
}

self.resultString = string_delete(self.resultString, 0, string_length(strdatablockCount));
ds_list_delete(self.usedNumbers, ds_list_find_index(self.usedNumbers, datablockCounts));