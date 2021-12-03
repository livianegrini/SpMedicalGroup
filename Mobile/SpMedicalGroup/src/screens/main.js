
import React ,{ Component } from 'react'
import {
    Image,
    StyleSheet,
    View,
} from 'react-native';

import Login from './login';
import ListarConsultas from './listarconsultas';
import { isFlowBaseAnnotation } from '@babel/types';
import { StatusBar } from 'react-native';


import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';

const bottomTab = createBottomTabNavigator();

class Main extends Component {

    render() {
        return (

            <View>
                <StatusBar>
                    hidden={isFlowBaseAnnotation}
                </StatusBar>


                <bottomTab.Navigator>

                    initialRouteName='Login'


                    screenOptions={({ Route }) => ({
                        tabBarIcon: () => {
                            // if (Route.name === 'Login') {
                            //     // return(
                            //     //     <Image>
                            //     //         source={require('../../assets/Listagem.png')}
                            //     //     </Image>
                            //     // )
                            // }
                            // if (Route.name === 'ListarProjetos') {
                            //     return (
                            //         <Image>
                            //             source={require('../../assets/Listagem.png')}
                            //         </Image>
                            //     )
                            // }

                            //Fazer essa parte
                        },
                        

                        headerShown: false,
                        tabBarShowlabel: false,
                        tabBarActiveBackgroundColor:  '#B727FF',
                        tabBarInactiveBackgroundColor: '#DD99FF',
                        tabBarStyle: { height: 50 }
                    })}

                    <bottomTab.Screen name="Login" Component={Login} />
                    <bottomTab.Screen name="ListarConsultas" Component={ListarConsultas} />

                </bottomTab.Navigator>
            </View>
        )
    }
};

const styles = StyleSheet.create({
    // conteúdo da main
    main: {
        flex: 1,
        backgroundColor: '#F1F1F1'
      },
    
      // estilo dos ícones da tabBar
      tabBarIcon: {
        width: 22,
        height: 22
    }
    
});


export default Main;
