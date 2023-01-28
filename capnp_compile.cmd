capnp compile -ocsharp capnpspecs/messages.capnp
robocopy capnpspecs/ zmq-capnp-unity/Assets/Scripts/Generated/ *.cs /MOV /IS /IT /FFT