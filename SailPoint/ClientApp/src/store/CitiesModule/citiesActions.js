
export const Actions = {
 
    async ['getData']({ commit }, { searchStr }) {

        console.log('getData searchstr: ' + searchStr);
        try{
            const furl = 'AutoComplete/?searchStr=' + searchStr;
            const Response = await fetch(furl);
            if (Response.ok) {
                Response.json().then((data) => {
                    if (Response.ok) {
                       
                        console.log('getData OK: ' + data.listItems);
                        commit('SET_DATA', { searchTerm: searchStr, data: data.listItems });

                    }
                    else {
                        commit('SET_ERROR', { error: data });
                        console.log(data);
                    }

                });
            }
            else {
                commit('SET_ERROR', { Response });
                console.log(Response);
            }
        }
        catch(error)
        {
            commit('SET_ERROR', { error: error });
            console.log(error); 
        }

    },
     
};
