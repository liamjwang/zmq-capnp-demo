# Lumbar Puncture MR
[![Build linux players](https://github.com/liamjwang/zmq-capnp-demo/zmq-capnp-unity/actions/workflows/build-linux.yml/badge.svg)](https://github.com/liamjwang/zmq-capnp-demo/zmq-capnp-unity/actions/workflows/build-linux.yml)
[![Build windows players](https://github.com/liamjwang/zmq-capnp-demo/zmq-capnp-unity/actions/workflows/build-windows.yml/badge.svg)](https://github.com/liamjwang/zmq-capnp-demo/zmq-capnp-unity/actions/workflows/build-windows.yml)


## Development
### CI Setup
- Assets/Editor/UnityBuilderAction is required for GameCI builds
  - Enables "Copy References", required for appx build from vs solution build to work

### References
- https://github.com/OpenAvikom/mr-grpc-unity
- https://github.com/rderbier/Hololens-QRcodeSample
- https://game.ci/

### Bugs
- slice rendering requires external window to be visible