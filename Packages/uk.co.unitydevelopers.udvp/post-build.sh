# see https://docs.unity.com/ugs/en-us/manual/devops/manual/build-automation/environment-variables
# see https://build-api.cloud.unity3d.com/docs/1.0.0/index.html
 
# set label using REST API
api_key='YOUR_API_KEY'
build_string=$(cat "$PROJECT_DIRECTORY/Assets/StreamingAssets/build.txt")

url="https://build-api.cloud.unity3d.com/api/v1/orgs/$ORG_ID/projects/$PROJECT_ID/buildtargets/$BUILD_TARGET/builds/$UCB_BUILD_NUMBER"

result=$(curl --http1.1 -X PUT -H "Content-Type: application/json" -H "Authorization: Basic $api_key" -d "{\"label\": \"$build_string\"}" "$url")

echo "Set label to $build_string $result"
