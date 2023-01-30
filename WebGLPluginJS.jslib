var LibraryMyPlugin = {
   $MyData: {
       myVar: 123,
   },
 
 CallFunction: function (param) {
  //window.alert(pointer_stringify(roomName));
  var roomname  = UTF8ToString(param);
  window.alert(UTF8ToString(param));
   //console.log(RoomName);
   function  Setvar(val) {
    MyData.myVar = val;
  }
 function Getvar() {
    return MyData.myVar;
  }
      // Show a message as an alert
   let audioCall = document.createElement("div");
    //audioCall.setAttribute("class", "root");
    audioCall.setAttribute("id", "root");
    document.body.appendChild(audioCall);
// first scene 
    const roomID = roomname;
    //console.log('roomname'+roomName);
    const userID = Math.floor(Math.random() * 10000000000000000000) + "";
    const userName = "userName" + userID;
    const appID = 1589850915;
    const serverSecret = "16870357c16906df1913d2e4fdb4603b";
    const kitToken =  ZegoUIKitPrebuilt.generateKitTokenForTest(appID, serverSecret, roomID, userID, userName);
    console.log(kitToken);

    const zp = ZegoUIKitPrebuilt.create(kitToken);

    console.log("ZegoUIKitPrebuilt",zp);

    zp.joinRoom({
        container: document.querySelector("#root"),
        sharedLinks: [{
            url: window.location.origin + window.location.pathname + '?roomID=' + roomID,
        }],
        scenario: {
           mode: ZegoUIKitPrebuilt.GroupCall, //  To implement 1-on-1 calls, modify the parameter here to [ZegoUIKitPrebuilt.OneONoneCall].
        },
          turnOnCameraWhenJoining: false,
          showMyCameraToggleButton: false,
          showAudioVideoSettingsButton: false,
          showScreenSharingButton: false,
          showPreJoinView: false,
          turnOnMicrophoneWhenJoining: false,
          
    });   
    // return zp;

      Setvar(zp);
   },
   // Function with the text param
   MicrophoneMute: function (param) {

    var roomname  = UTF8ToString(param);
    window.alert(UTF8ToString(param));

    function  Setvar(val) {
    MyData.myVar = val;
      }
 function Getvar() {
    return MyData.myVar;
  }
//function muteMe(elem) {elem.muted = false;elem.pause();}// Try to mute all video and audio elements on the page
//function mutePage() {
    //var elems = document.querySelectorAll("audio");
   // console.warn("audio",elems);
    //[].forEach.call(elems, function(elem) { muteMe(elem); });
//}
//mutePage();

// const element = document.getElementById("root");
 // element.remove();
  
   var previous_room = Getvar();
   previous_room.destroy();
 
   const roomID = roomname;
   
    const userID = Math.floor(Math.random() * 10000000000000000000) + "";
    const userName = "userName" + userID;
    const appID = 1589850915;
    const serverSecret = "16870357c16906df1913d2e4fdb4603b";
    const kitToken =  ZegoUIKitPrebuilt.generateKitTokenForTest(appID, serverSecret, roomID, userID, userName);
    console.log(kitToken);

    const zp = ZegoUIKitPrebuilt.create(kitToken);
    zp.joinRoom({
        container: document.querySelector("#root"),
        sharedLinks: [{
            url: window.location.origin + window.location.pathname + '?roomID=' + roomID,
        }],
        scenario: {
           mode: ZegoUIKitPrebuilt.GroupCall, //  To implement 1-on-1 calls, modify the parameter here to [ZegoUIKitPrebuilt.OneONoneCall].
        },
          turnOnCameraWhenJoining: false,
          showMyCameraToggleButton: false,
          showAudioVideoSettingsButton: false,
          showScreenSharingButton: false,
          showPreJoinView: false,
          turnOnMicrophoneWhenJoining: false,
    });

     Setvar(zp);
   },
    MicrophoneUnMute: function (param) {
      var roomname  = UTF8ToString(param);
      window.alert(UTF8ToString(param));
   function  Setvar(val) {
    MyData.myVar = val;
  }
 function Getvar() {
    return MyData.myVar;
  }
  
   var previous_room = Getvar();
   previous_room.destroy();

   const roomID = roomname;
    const userID = Math.floor(Math.random() * 10000000000000000000) + "";
    const userName = "userName" + userID;
    const appID = 1589850915;
    const serverSecret = "16870357c16906df1913d2e4fdb4603b";
    const kitToken =  ZegoUIKitPrebuilt.generateKitTokenForTest(appID, serverSecret, roomID, userID, userName);
    console.log(kitToken);

    const zp = ZegoUIKitPrebuilt.create(kitToken);
    zp.joinRoom({
        container: document.querySelector("#root"),
        sharedLinks: [{
            url: window.location.origin + window.location.pathname + '?roomID=' + roomID,
        }],
        scenario: {
           mode: ZegoUIKitPrebuilt.GroupCall, //  To implement 1-on-1 calls, modify the parameter here to [ZegoUIKitPrebuilt.OneONoneCall].
        },
          turnOnCameraWhenJoining: false,
          showMyCameraToggleButton: false,
          showAudioVideoSettingsButton: false,
          showScreenSharingButton: false,
          showPreJoinView: false,
        
    });
       const replacerFunc = () => {
    const visited = new WeakSet();
    return (key, value) => {
      if (typeof value === "object" && value !== null) {
        if (visited.has(value)) {
          return;
        }
        visited.add(value);
      }
      return value;
    };
  };
  Setvar(zp);
   },
   // Function with the number param
   PassNumberParam: function (number) {

   },
   // Function returning text value
   GetTextValue: function () {
      // Define text value
      var textToPass = "You got this text from the plugin";
      // Create a buffer to convert text to bytes
      var bufferSize = lengthBytesUTF8(textToPass) + 1;
      var buffer = _malloc(bufferSize);
      // Convert text
      stringToUTF8(textToPass, buffer, bufferSize);
      // Return text value
      return buffer;
   },
   // Function returning number value
   GetNumberValue: function () {
      // Return number value
      return 2020;
   },
   // change room function 
 ChangeRoom : function(param)
   {
    var roomname  = UTF8ToString(param);
    //console.log("ChangeRoom----------------");
    //console.log("roomName------"+roomname);
    window.alert(UTF8ToString(param));

    function  Setvar(val) {
    MyData.myVar = val;
  }
 function Getvar() {
    return MyData.myVar;
  }

  var previous_room = Getvar();
  previous_room.destroy();

  const roomID = roomname;
  const userID = Math.floor(Math.random() * 10000000000000000000) + "";
  const userName = "userName" + userID;
  const appID = 1589850915;
  const serverSecret = "16870357c16906df1913d2e4fdb4603b";
  const kitToken =  ZegoUIKitPrebuilt.generateKitTokenForTest(appID, serverSecret, roomID, userID, userName);
  console.log(kitToken);

  const zp = ZegoUIKitPrebuilt.create(kitToken);
  zp.joinRoom({
      container: document.querySelector("#root"),
      sharedLinks: [{
          url: window.location.origin + window.location.pathname + '?roomID=' + roomID,
      }],
      scenario: {
         mode: ZegoUIKitPrebuilt.GroupCall, //  To implement 1-on-1 calls, modify the parameter here to [ZegoUIKitPrebuilt.OneONoneCall].
      },
        turnOnCameraWhenJoining: false,
        showMyCameraToggleButton: false,
        showAudioVideoSettingsButton: false,
        showScreenSharingButton: false,
        showPreJoinView: false,
        turnOnMicrophoneWhenJoining: false,
  });

   Setvar(zp);
   
   }, 
   DisconnectCall: function(param)
   {
        console.log("param-------------"+param);
        //window.alert(pointer_stringify(param));
        window.alert(UTF8ToString(param));
   }

};
 
autoAddDeps(LibraryMyPlugin, '$MyData');
mergeInto(LibraryManager.library, LibraryMyPlugin);

