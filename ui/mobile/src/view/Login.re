open ReactNative;

type state = {
  count: int,
  show: bool,
};

type action =
  | Click
  | Toogle;

let reducer = (state, action) =>
  switch (action) {
  | Click => {...state, count: state.count + 1}
  | Toogle => {...state, show: !state.show}
  };

let initialState = {count: 0, show: true};

[@react.component]
let make = (~message) => {
  let (state, dispatch) = React.useReducer(reducer, initialState);

  <View>
    <Button title="click" onPress={_ => dispatch(Click)} />
    <Button title="show" onPress={_ => dispatch(Toogle)} />
    <Text>
      {React.string(message ++ " " ++ string_of_int(state.count))}
    </Text>
  </View>;
};