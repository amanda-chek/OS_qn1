image_index ++;
checked =!checked;


if (checked == true) {
	
	//if(global.index!= 0 ){
		ds_list_add(global.array,box);
		
		 
    if (global.answerString != "") {
        global.answerString += ", ";
    }
		global.answerString += string(box);
		
    //ds_list_insert(global.array,global.index, box);
    //show_message(global.answerString);
    // Update self.arrayString to include 'box'
	//if (global.bigbox <= box ) //if bigbox is smaller or equal than box take box value.
	//{ global.bigbox =box }
	

	
} else {
	global.index = ds_list_find_index(global.array, box);
	if( global.index == ds_list_size(global.array) - 1 ){
		
		ds_list_delete(global.array, global.index);
		global.answerString=string_delete(global.answerString,global.index,string_length(box));
		
		
	}
	else{
		tempo= string(box)+"~~"; // 3	
		ds_list_delete(global.array, global.index);
	global.answerString=string_delete(global.answerString,global.index,string_length(tempo));
	}

}
/*
for( var i =0; i<global.index; i++){
	show_message(ds_list_size(global.array));
	a = ds_list_find_value(global.array,ds_list_size(global.array));
}
show_message(a);