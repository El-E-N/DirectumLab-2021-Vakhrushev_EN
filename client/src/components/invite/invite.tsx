import * as React from 'react';
import Header from '../header/header';
import Main from '../main/main';
import Footer from '../footer/footer';

interface IArrayElement {
  label: string;
  placeHolder: string;
  name: string;
}

const values: Array<IArrayElement> = [
  {label: 'User name', placeHolder: 'Enter your name', name: 'userName'}
];

const Invite: React.FunctionComponent = () => {
  return <React.Fragment>
    <Header />
    <Main className={'invite'} mainTitle={'Join the room:'} values={values} />
    <Footer />
  </React.Fragment>;
};

export default Invite;
