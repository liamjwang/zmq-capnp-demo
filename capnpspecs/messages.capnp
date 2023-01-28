@0xba82d15686573996;

struct Vector3 {
    x @0 :Float32;
    y @1 :Float32;
    z @2 :Float32;
}

struct HandPose {
    finger @0 :List(Vector3);
}
