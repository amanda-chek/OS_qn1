/// @DnDAction : YoYo Games.Common.Execute_Code
/// @DnDVersion : 1
/// @DnDHash : 212FB832
/// @DnDArgument : "code" "var match = true;$(13_10)var listSize = ds_list_size(global.array);$(13_10)$(13_10)if (ds_list_size(obj_Data_Blocks.usedNumbers) != listSize) {$(13_10)    match = false; // If sizes are different, they can't be equal$(13_10)} else {$(13_10)    for (var i = 0; i < listSize; i++) {$(13_10)        var value1 = ds_list_find_value(global.array, i);$(13_10)        var value2 = ds_list_find_value(obj_Data_Blocks.usedNumbers, i);$(13_10)        $(13_10)        if (value1 != value2) {$(13_10)            match = false;$(13_10)            break; $(13_10)        }$(13_10)    }$(13_10)}$(13_10)$(13_10)if (match) {$(13_10)    show_message("Success");$(13_10)} else {$(13_10)    show_message("Fail");$(13_10)}$(13_10)"
var match = true;
var listSize = ds_list_size(global.array);

if (ds_list_size(obj_Data_Blocks.usedNumbers) != listSize) {
    match = false; // If sizes are different, they can't be equal
} else {
    for (var i = 0; i < listSize; i++) {
        var value1 = ds_list_find_value(global.array, i);
        var value2 = ds_list_find_value(obj_Data_Blocks.usedNumbers, i);
        
        if (value1 != value2) {
            match = false;
            break; 
        }
    }
}

if (match) {
    show_message("Success");
} else {
    show_message("Fail");
}