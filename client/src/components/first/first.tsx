import * as React from 'react';
import Header from '../header/header';
import Main, {IArrayElement} from '../main/main';
import Footer from '../footer/footer';

const values: Array<IArrayElement> = [
  {label: 'User name', placeHolder: 'Enter your name', name: 'userName'},
  {label: 'Room name', placeHolder: 'Enter room name', name: 'roomName'}
];

const First: React.FunctionComponent = () => {
  return <React.Fragment>
    <Header />
    <Main mainTitle={'Create the room:'} values={values} />
    <Footer />
  </React.Fragment>;
};

export default First;
