
<template>
<div class='container'>
 <div id='updateButton'>
    <a v-on:click=" isFileFormShown = true" v-if="!isFileFormShown" class="btn btn-success">Upload A Picture</a>
    </div>
	<div id='UploadFile' v-if="isFileFormShown">
		<div id="uploadContainer">
			<div class="large-12 medium-12 small-12 cell" id="selectFiles">
				<h2>Select Files</h2>
				<label for="select-files">
					<input id="select-files" type="file" multiple @change="handleFilesUpload( $event )"/>
				</label>
			</div>
			<div class="large-12 medium-12 small-12" id="">
				<div 
					v-for="(file, key) in files" 
					v-bind:key="'file-'+key"
					class="file-listing">{{ file.name }} <span class="remove-file" v-on:click="removeFile( key )">Remove</span>
				</div>
			</div>
			<br>
			<div class="large-12 medium-12 small-12 cell">
				<button v-on:click="addFiles()">Add Files</button>
			</div>
			<br>
			<div class="large-12 medium-12 small-12 cell">
				<button v-on:click="submitFiles()" id="uploadSubmit">Submit</button>
            <button v-on:click.prevent="resetForm" class="btn btn-success" value="Cancel" id="uploadCancel">Cancel</button>
			</div>
		</div>
	</div>
</div>
</template>

<script>
	import axios from 'axios';
	
	export default {
		/*
			Defines the data used by the component
		*/
		data(){
			return {
				files: [],
				isFileFormShown:  false
			}
		},
		/*
			Defines the method used by the component
		*/
		methods: {
  resetForm() {
      this.isFileFormShown = false;

    },
			/*
				Adds a file
			*/
			addFiles(){
				document.getElementById('select-files').click();
			},
			/*
				Submits files to the server
			*/
			submitFiles(){
				/*
					Initialize the form data
				*/
				let formData = new FormData();
				/*
					Iterate over any file sent over appending the files
					to the form data.
				*/
				for( var i = 0; i < this.files.length; i++ ){
					let file = this.files[i];
					formData.append('files[' + i + ']', file);
				}
				/*
					Make the request to the POST /select-files URL
				*/
				axios.post( '/select-files',
					formData,
					{
						headers: {
								'Content-Type': 'multipart/form-data'
						}
					}
				).then(function(){
					console.log('SUCCESS!!');
				})
				.catch(function(){
					console.log('FAILURE!!');
				});
			},
			/*
				Handles the uploading of files
			*/
			handleFilesUpload( event ){
				let uploadedFiles = event.target.files;
				/*
					Adds the uploaded file to the files array
				*/
				for( var i = 0; i < uploadedFiles.length; i++ ){
					this.files.push( uploadedFiles[i] );
				}
			},
			/*
				Removes a select file the user has uploaded
			*/
			removeFile( key ){
				this.files.splice( key, 1 );
			}
		}
	}
</script>

<style scoped>
	input[type="file"]{
		position: absolute;
		top: -500px;
	}
	div.file-listing{
		width: 400px;
		margin: auto;
	}
	span.remove-file{
		color: red;
		cursor: pointer;
		float: right;
	}
    div#uploadContainer{
        display: flex;
        flex-direction: column;
		align-items: center;
		justify-content: center;

    }
	div#selectFiles h2{
  font-family:Impact, Haettenschweiler, 'Arial Narrow Bold', sans-serif;
  color: rgb(180, 85, 21);
  font-size: 1.75rem;
	}
	button#uploadSubmit{
		margin:5px;
	}
	button#uploadCancel{
		margin:5px;
	}
</style>