open ReactNative;
open Style;

let styles =
  StyleSheet.create({
    "container":
      style(
        ~flex=1.0,
        ~justifyContent=`center,
        ~alignItems=`center,
        ~backgroundColor="tomato",
        (),
      ),
  });

[@react.component]
let app = () =>
  <View style=styles##container>
    <Login message="Hello World" />
    <Other />
  </View>;